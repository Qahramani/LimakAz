using LimakAz.Application.Interfaces.Helpers;
using LimakAz.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LimakAz.Persistence.Implementations.Services;

internal class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICountryService _countryService;
    private readonly ILocalPointService _localPointService;
    private readonly ITariffService _tariffService;
    private readonly IValidationMessageProvider _localizer;
    private readonly IStatusService _statusService;
    private readonly UserManager<AppUser> _userManager;
    private readonly ICookieService _cookieService;
    private readonly IAuthService _authService;
    public OrderService(IOrderRepository repository, IMapper mapper, ICountryService countryService, ILocalPointService localPointService, ITariffService tariffService, IValidationMessageProvider localizer, IStatusService statusService, UserManager<AppUser> userManager, ICookieService cookieService, IAuthService authService)
    {
        _repository = repository;
        _mapper = mapper;
        _countryService = countryService;
        _localPointService = localPointService;
        _tariffService = tariffService;
        _localizer = localizer;
        _statusService = statusService;
        _userManager = userManager;
        _cookieService = cookieService;
        _authService = authService;
    }

    public async Task<bool> CreateAsync(OrderCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var isExist = await _countryService.IsExistAsync(dto.CountryId);

        if (!isExist)
        {
            ModelState.AddModelError("", _localizer.GetValue("FailureMessage"));
            return false;
        };

        isExist = await _localPointService.IsExistAsync(dto.LocalPointId);

        if (!isExist)
        {
            ModelState.AddModelError("", _localizer.GetValue("FailureMessage"));
            return false;
        };

        var order = _mapper.Map<Order>(dto);

        var selectedCountry = await _countryService.GetAsync(dto.CountryId);

        if (selectedCountry!.Id == (int)CountryName.Turkiye)
            order.OrderTotalPrice = (dto.LocalCargoPrice + (dto.ItemPrice * dto.Count)) * 1.05m;
        else
            order.OrderTotalPrice = (dto.LocalCargoPrice + (dto.ItemPrice * dto.Count)) * 1.07m;

        order.StatusId = (int)StatusName.NotOrdered;

        var user = await _authService.GetAuthenticatedUserAsync();

        if (user == null)
            throw new UnAuthorizedException();

        order.UserId = user.Id;

        await _repository.CreateAsync(order);
        await _repository.SaveChangesAsync();

        return true;

    }

    public async Task<int> DecreaseOrderCount(int itemId)
    {
        var order = await _repository.GetAsync(itemId);

        if (order == null)
            throw new NotFoundException("Bu idli baglama tapilmadi");


        order.Count = order.Count == 1 ? 1 : --order.Count;

        _repository.Update(order);
        await _repository.SaveChangesAsync();

        return order.Count;
    }

    public async Task DeleteAsync(int id)
    {
       var item = await _repository.GetAsync(id);

        if (item == null)
            throw new NotFoundException();

        _repository.SoftDelete(item);

        await _repository.SaveChangesAsync();
    }
    public List<OrderGetDto> GetAll(LanguageType language = LanguageType.Azerbaijan)
    {
        throw new NotImplementedException();
    }

    public Task<OrderGetDto> GetAsync(int id, LanguageType language = LanguageType.Azerbaijan)
    {
        throw new NotImplementedException();
    }

    public async Task<OrderCreateDto> GetCreateDtoAsync(OrderCreateDto dto, LanguageType language = LanguageType.Azerbaijan)
    {
        var countries = _countryService.GetAll(language);
        var localPoints = _localPointService.GetAll(language);

        dto.Countries = countries;
        dto.LocalPoints = localPoints;
        var userId = _cookieService.GetUserId();

        var user = await _userManager.FindByIdAsync(userId);

        if (dto.LocalPointId == 0 && user != null)
            dto.SelectedLocalPointId = user.LocalPointId;

        return dto;
    }
    public Task<PaginateDto<OrderGetDto>> GetPagesAsync(LanguageType language = LanguageType.Azerbaijan, int page = 1, int limit = 10)
    {
        throw new NotImplementedException();
    }

    public Task<OrderUpdateDto> GetUpdatedDtoAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<OrderGetDto>> GetUserOrdersByCountryId(int countryId)
    {
        var isExsist = await _countryService.IsExistAsync(countryId);

        if (!isExsist)
            throw new NotFoundException("Bu idli olke tapilmadi");

        var user = await _authService.GetAuthenticatedUserAsync();

        var orders =  _repository.GetAll(x => x.CountryId == countryId && x.UserId == user.Id);

        var dtos =  _mapper.Map<List<OrderGetDto>>(orders);

        return dtos;
    }

    public async Task<int> IncreaseOrderCount(int itemId)
    {
        var order = await _repository.GetAsync(itemId);

        if (order == null)
            throw new NotFoundException("Bu idli baglama tapilmadi");

        order.Count += 1;

         _repository.Update(order);
        await _repository.SaveChangesAsync();

        return order.Count;
    }

    public Task<bool> IsExistAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(OrderUpdateDto dto, ModelStateDictionary ModelState)
    {
        throw new NotImplementedException();
    }
}
