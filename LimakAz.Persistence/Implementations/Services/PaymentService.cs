namespace LimakAz.Persistence.Implementations.Services;

using LimakAz.Domain.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;


internal class PaymentService : IPaymentService
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IConfiguration _configuration;
    private readonly PaymentConfigurationDto _paymentConfigurationDto;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IUrlHelper _urlHelper;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ILanguageService _languageService;
    private readonly IPaymentRepository _repository;

    public PaymentService(IWebHostEnvironment webHostEnvironment, IConfiguration configuration, IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor, IHttpContextAccessor contextAccessor, IHttpClientFactory httpClientFactory, ILanguageService languageService, IPaymentRepository repository)
    {
        _webHostEnvironment = webHostEnvironment;
        _configuration = configuration;
        _paymentConfigurationDto = _configuration.GetSection("PaymentSettings").Get<PaymentConfigurationDto>() ?? new();
        _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext ?? new());
        _contextAccessor = contextAccessor;
        _httpClientFactory = httpClientFactory;
        _languageService = languageService;
        _repository = repository;
    }

    public async Task<bool> ConfirmPaymentAsync(PaymentCheckDto dto)
    {
        var payment = await _repository.GetAsync(x => x.ConfirmToken == dto.Token && x.ReceptId == dto.ID, include: x => x.Include(x => x.Package).ThenInclude(x => x.OrderItems));

        if (payment is null)
            throw new NotFoundException();

        if (dto.STATUS == PaymentStatuses.Cancelled)
        {


            foreach (var order in payment.Package.OrderItems)
            {
                order.PackageId = null;
            }

            payment.Package.StatusId = (int)StatusName.IsCanceled;

            _repository.SoftDelete(payment);
            await _repository.SaveChangesAsync();

            return false;
        }

        payment.PaymentStatus = PaymentStatuses.FullyPaid;
        payment.Package!.StatusId = (int)StatusName.Paid;
        payment.Package.PaymentId = dto.ID;

        foreach (var order in payment.Package.OrderItems)
        {
            order.StatusId = (int)StatusName.Paid;
            order.CreatedAt = DateTime.UtcNow;
        }

        _repository.Update(payment);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task<PaymentResponseDto> CreateAsync(PaymentCreateDto dto)
    {

        string token = Guid.NewGuid().ToString();

        UrlActionContext context = new()
        {
            Action = "CheckPayment",
            Controller = "Order",
            Values = new { token },
            Protocol = _contextAccessor.HttpContext?.Request.Scheme
        };

        var redirectUrl = _urlHelper.Action(context);


        string amount = dto.Amount.ToString().Replace(',', '.');


        string requestBody = $@"
    {{
        ""order"": {{
            ""typeRid"": ""Order_SMS"",
            ""amount"": {amount},
            ""currency"": ""AZN"",
            ""language"": ""az"",
            ""description"": ""{dto.Description}"",
            ""hppRedirectUrl"": ""{redirectUrl}"",
            ""hppCofCapturePurposes"": [""Cit""]
        }}
    }}";

        var httpClient = _httpClientFactory.CreateClient("KapitalBankClient");
        var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_paymentConfigurationDto.Username}:{_paymentConfigurationDto.Password}"));
        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);


        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(_paymentConfigurationDto.BaseUrl, content);

        if (!response.IsSuccessStatusCode)
            throw new Exception(response.StatusCode.ToString());

        var responseContent = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<PaymentResponseDto>(responseContent) ?? new();

        Payment payment = new()
        {
            Amount = dto.Amount,
            Description = dto.Description,
            ReceptId = result.Order.Id,
            SecretId = result.Order.Secret,
            PaymentStatus = PaymentStatuses.Pending,
            ConfirmToken = token,
            PackageId = dto.PackageId
        };

        await _repository.CreateAsync(payment);
        await _repository.SaveChangesAsync();

        result.PaymentId = payment.Id;

        return result;
    }
}
