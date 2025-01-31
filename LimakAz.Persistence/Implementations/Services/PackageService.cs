
using LimakAz.Application.Interfaces.Services;
using LimakAz.Application.Interfaces.Services.External;
using LimakAz.Domain.Enums;
using LimakAz.Persistence.Helpers;
using LimakAz.Persistence.Implementations.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Runtime.CompilerServices;

namespace LimakAz.Persistence.Implementations.Servicesl;

internal class PackageService : IPackageService
{
    private readonly IPackageRepository _repository;
    private readonly IAuthService _authService;
    private readonly IOrderService _orderService;
    private readonly IPaymentService _paymentService;
    private readonly ICurrencyService _currencyService;
    private readonly IMapper _mapper;
    private readonly ICountryService _countryService;
    private readonly ILocalPointService _localPointService;
    private readonly IStatusService _statusService;
    private readonly ITariffService _tariffService;
    private readonly IEmailService _emailService;
    private readonly string _staticFilesPath;
    
    public PackageService(IPackageRepository repository, IAuthService authService, IOrderService orderService, IPaymentService paymentService, ICurrencyService currencyService, IMapper mapper, ICountryService countryService, IStatusService statusService, ILocalPointService localPointService, ITariffService tariffService, IEmailService emailService)
    {
        _repository = repository;
        _authService = authService;
        _orderService = orderService;
        _paymentService = paymentService;
        _currencyService = currencyService;
        _mapper = mapper;
        _countryService = countryService;
        _statusService = statusService;
        _localPointService = localPointService;
        _tariffService = tariffService;
        var root = Helper.GetSolutionRoot();
        _staticFilesPath = Path.Combine(root, "LimakAz.Infrastructure", "StaticFiles");
        _emailService = emailService;
    }

    public async Task<string> CreatePacakageAsync(OrderBasketDto dto)
    {
        var user = await _authService.GetAuthenticatedUserAsync();

        if (dto.SelectedOrderIds.Count == 0)
            throw new EmptyBasketException();

        var isExist = await _localPointService.IsExistAsync(dto.LocalPointId);

        if (!isExist)
            throw new NotFoundException("Bu Idli yerli anbar tapilmadi");

        List<OrderItemGetDto> allUserOrders = await _orderService.GetUsersOrdersAsync(user.Id);

        var selectedOrders = new List<OrderItemGetDto>();
        int? countryId = null;
        foreach (var orderId in dto.SelectedOrderIds)
        {
            var selectedOrder = allUserOrders.FirstOrDefault(x => x.Id == orderId);
            
            if(selectedOrder == null || selectedOrder.StatusId != (int)StatusName.NotOrdered)
                throw new NotFoundException($"{orderId}li sifaris tapilmadi");

            if (countryId == null)
                countryId = selectedOrder.CountryId;
            else if (countryId != selectedOrder.CountryId)
                throw new InvalidInputException("Butun sefiraslerin bir olkeye mexsus olmasi mutleqdir");

            selectedOrders.Add(selectedOrder);
        }

        decimal totalPrice = 0;
        string packageNo = Helper.GeneratePackageNO();
        selectedOrders.ForEach(x => totalPrice += x.OrderItemTotalPrice);

        Package package = new()
        {
            UserId = user.Id,
            CountryId = (int)countryId!,
            TotalPrice = totalPrice,
            StatusId = (int)StatusName.NotOrdered,
            NO = packageNo,
            LocalPointId= dto.LocalPointId
        };

        var createdPackage = await _repository.CreateAsync(package);
        await _repository.SaveChangesAsync();

        await _orderService.SetPackageIdsAsync(selectedOrders, package.Id);

        decimal totalPriceInAZN = 0;

        if (countryId == 1)
            totalPriceInAZN = await _currencyService.ConvertAsync(totalPrice, "TRY", "AZN");
        else
            totalPriceInAZN = await _currencyService.ConvertAsync(totalPrice, "USD", "AZN");

        PaymentCreateDto paymentCreate = new()
        {
            Amount = totalPriceInAZN,
            Description = "Limak odenis",
            PackageId = createdPackage.Id
        };

        var result = await _paymentService.CreateAsync(paymentCreate);

        await _repository.SaveChangesAsync();

        string url = $"{result.Order.HppUrl}?id={result.Order.Id}&password={result.Order.Password}";

        return url;
    }

    public async Task<PackageGetUserDto> GetAuthenticatedUserPackages(int statusId, LanguageType language = LanguageType.Azerbaijan)
    {

        var isExist = await _statusService.IsExistAsync(statusId);

        if (statusId != 0 && !isExist)
            throw new NotFoundException("Bu idli status tapilmadi");

        var user = await _authService.GetAuthenticatedUserAsync();

        var packages = _repository.GetAll(x => x.UserId == user.Id && x.StatusId != (int)StatusName.NotOrdered && x.StatusId != (int)StatusName.Ordered, include: _getWithIncludes(language));

        
        if (statusId != 0)
            packages = packages.Where(x => x.StatusId == statusId);

        packages = packages.OrderByDescending(x => x.CreatedAt);

        var dtos = _mapper.Map<List<PackageGetDto>>(packages);
        
        var statuses = _statusService.GetAll(language);

        PackageGetUserDto dto = new()
        {
            Packages = dtos,
            Statuses = statuses,
            SelectedStatusId = statusId
        };

        return dto;
    }

    private static Func<IQueryable<Package>, IIncludableQueryable<Package, object>> _getWithIncludes(LanguageType language)
    {
        return x => x
        .Include(x => x.Country).ThenInclude(x => x.CountryDetails.Where(x => x.LanguageId == (int)language))
        .Include(x => x.Status).ThenInclude(x => x.StatusDetails.Where(x => x.LanguageId == (int)language))
        .Include(x => x.LocalPoint).ThenInclude(x => x.LocalPointDetails.Where(x => x.LanguageId == (int)language))
        .Include(x => x.OrderItems)
        .Include(x => x.User)
        .Include(x => x.Payment)!;
    }
    private static Func<IQueryable<Package>, IIncludableQueryable<Package, object>> _getWithIncludes()
    {
        return x => x
        .Include(x => x.Country).ThenInclude(x => x.CountryDetails)
        .Include(x => x.Status).ThenInclude(x => x.StatusDetails)
        .Include(x => x.LocalPoint).ThenInclude(x => x.LocalPointDetails)
        .Include(x => x.OrderItems)
        .Include(x => x.User)
        .Include(x => x.Payment)!;
    }


    public async Task<PackageGetAdminDto> GetFilteredPackagesAsync(int statusId = 0, LanguageType language = LanguageType.Azerbaijan)
    {
        var query = _repository.GetAll(include : _getWithIncludes(language)); 

        var isExist = await _statusService.IsExistAsync(statusId);

        if (statusId != 0 && !isExist)
            throw new NotFoundException($"{statusId}-li status tapilmadi");

        if (statusId != 0)
            query = query.Where(x => x.StatusId == statusId);

        var packages = await _repository.OrderByDescending(query,x => x.CreatedAt).ToListAsync();

        var dtos = _mapper.Map<List<PackageGetDto>>(packages);

        PackageGetAdminDto dto = new()
        {
            Packages = dtos,
            SelectedStatusId = statusId
        };

        return dto;
    }

    public async Task CancelPackageAsync(int id)
    {
        var order = await _repository.GetAsync(x => x.Id == id, x => x.Include(x => x.OrderItems));

        if (order is null)
            throw new NotFoundException();

        order.StatusId = (int)StatusName.IsCanceled;

        _repository.Update(order);
        await _repository.SaveChangesAsync();
    }

    public async Task RepairPackageAsync(int id)
    {
        var package = await _repository.GetAsync(x => x.Id == id, x => x.Include(x => x.OrderItems));

        if (package is null)
            throw new NotFoundException();

        if (package.StatusId != (int)StatusName.IsCanceled)
            return;

        package.StatusId = (int)StatusName.Paid;

        _repository.Update(package);
        await _repository.SaveChangesAsync();
    }

    public async Task NextOrderStatusAsync(int id)
    {
        var package = await _repository.GetAsync(x => x.Id == id, _getWithIncludes());

        if (package == null) throw new NotFoundException($"{id}-li baglama tapilmadi");

        if (package.StatusId == 6)
            return;

        if (package.StatusId < 6)
            package.StatusId++;

         _repository.Update(package);

        await _repository.SaveChangesAsync();

    }

    public async Task PrevOrderStatusAsync(int id)
    {

        var package = await _repository.GetAsync(x => x.Id == id, _getWithIncludes());

        if (package == null) throw new NotFoundException($"{id}-li baglama tapilmadi");

        if (package.StatusId == 7)
            return;

        if (package.StatusId > 2)
            package.StatusId--;

        _repository.Update(package);

        await _repository.SaveChangesAsync();

    }

    public async Task<PackageGetDto> GetAsync(int id, LanguageType language = LanguageType.Azerbaijan)
    {
        var package = await _repository.GetAsync(x => x.Id == id, _getWithIncludes());

        if (package == null) throw new NotFoundException($"{id}-li baglama tapilmadi");

        var dto = _mapper.Map<PackageGetDto>(package);

        return dto;

    }

    public async Task DeleteAsync(int id)
    {
        var package = await _repository.GetAsync(x => x.Id == id, _getWithIncludes());

        if (package == null) throw new NotFoundException($"{id}-li baglama tapilmadi");

        _repository.SoftDelete(package);

        await _repository.SaveChangesAsync();
    }

    public async Task UpdateWeigth(int id, decimal weigth)
    {
        var package = await _repository.GetAsync(x => x.Id == id, _getWithIncludes());

        if (package == null) throw new NotFoundException($"{id}-li baglama tapilmadi");

        var cargoPrice = await _tariffService.GetCargoPriceByWeightAsync(weigth,(int)package.CountryId!);

        package.TotalCargoPrice = cargoPrice;
        package.TotalWeigth = weigth;

        _repository.Update(package);
        await _repository.SaveChangesAsync();
    }

    public async Task SendNotificationEmail(int packageId)
    {
        var package = await _repository.GetAsync(x => x.Id == packageId, _getWithIncludes());

        if (package == null)
            throw new NotFoundException($"{packageId}-li baglama tapilmadi");

        NotificationEmailDto dto = new()
        {
            Fullname = package.User?.Firstname + " " + package.User?.Lastname,
            NO = package.NO!,
            CargoPrice = package.TotalCargoPrice.ToString(),
            LocalPointName = package.LocalPoint.LocalPointDetails.FirstOrDefault()!.Name,
            CreatedAt = DateTime.UtcNow,
        };

        string emailBody = await _getTemplateContentAsync( dto, "NitificationBody.html");


        EmailSendDto emailSendDto = new()
        {
            Body = emailBody,
            Subject = "Email Təsdiqləmə",
            ToEmail = package.User!.Email ?? "undifined@undifined.com"
        };

        await _emailService.SendEmailAsync(emailSendDto);
    }

    
    private async Task<string> _getTemplateContentAsync( NotificationEmailDto dto, string filename)
    {
        string path = Path.Combine(_staticFilesPath, filename);

        if (!File.Exists(path))
            throw new FileNotFoundException("Bele bir Template tapilmadi");

        string templateContent;
        using (var reader = new StreamReader(path))
        {
            templateContent = await reader.ReadToEndAsync();
        }

        templateContent = templateContent
            .Replace("{{Fullname}}", dto.Fullname).Replace("{{NO}}", dto.NO)
            .Replace("{{CargoPrice}}", dto.CargoPrice).Replace("{{LocalPointName}}", dto.LocalPointName)
            .Replace("{{CreatedAt}}", dto.CreatedAt.ToString("yyyy, dd MMMM", new System.Globalization.CultureInfo("az-Latn-AZ")));

        return templateContent;
    }

    public async Task FinishOrderAsync(int id)
    {
        var package = await _repository.GetAsync(id);

        if (package == null)
            throw new NotFoundException();

        package.StatusId = (int)StatusName.OrderIsDone;

        _repository.Update(package);
        await _repository.SaveChangesAsync();
    }
}

