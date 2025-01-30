using LimakAz.Application.Interfaces.Services.External;
using LimakAz.Domain.Enums;
using LimakAz.Persistence.Helpers;
using LimakAz.Persistence.Localizers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace LimakAz.Persistence.Implementations.Services;

internal class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICountryService _countryService;
    private readonly ILocalPointService _localPointService;
    private readonly ITariffService _tariffService;
    private readonly OrderLocalizer _localizer;
    private readonly IStatusService _statusService;
    private readonly UserManager<AppUser> _userManager;
    private readonly ICookieService _cookieService;
    private readonly IAuthService _authService;
    private readonly ICurrencyService _currencyService;
    public OrderService(IOrderRepository repository, IMapper mapper, ICountryService countryService, ILocalPointService localPointService, ITariffService tariffService, OrderLocalizer localizer, IStatusService statusService, UserManager<AppUser> userManager, ICookieService cookieService, IAuthService authService, ICurrencyService currencyService)
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
        _currencyService = currencyService;
    }

    public async Task<bool> CreateAsync(OrderItemCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var isExist = await _countryService.IsExistAsync(dto.CountryId);

        if (!isExist)
        {
            ModelState.AddModelError("", _localizer.GetValue("FailureMessage"));
            return false;
        };

        var order = _mapper.Map<OrderItem>(dto);

        var selectedCountry = await _countryService.GetAsync(dto.CountryId);

        if (selectedCountry!.Id == (int)CountryName.Turkiye)
        {
            order.OrderItemTotalPrice = (dto.LocalCargoPrice + (dto.ItemPrice * dto.Count)) * 1.05m;
        }
        else
        {

            order.OrderItemTotalPrice = (dto.LocalCargoPrice + (dto.ItemPrice * dto.Count)) * 1.07m;
        }

        
        
        order.StatusId = (int)StatusName.NotOrdered;

        var user = await _authService.GetAuthenticatedUserAsync();

        if (user == null)
            throw new UnAuthorizedException();

        order.UserId = user.Id;

        await _repository.CreateAsync(order);
        await _repository.SaveChangesAsync();

        return true;

    }

   
    public async Task DeleteAsync(int id)
    {
        var item = await _repository.GetAsync(id);

        if (item == null)
            throw new NotFoundException();

        _repository.SoftDelete(item);

        await _repository.SaveChangesAsync();
    }
    public List<OrderItemGetDto> GetAll(LanguageType language = LanguageType.Azerbaijan)
    {
        var orders = _repository.GetAll(include: _getWithIncludes(language));

        var dtos = _mapper.Map<List<OrderItemGetDto>>(orders);

        return dtos;
    }

    public async Task<OrderItemGetDto> GetAsync(int id, LanguageType language = LanguageType.Azerbaijan)
    {
        var order = await _repository.GetAsync(x => x.Id == id, _getWithIncludes(language));

        if (order == null)
            throw new NotFoundException();

        var dto = _mapper.Map<OrderItemGetDto>(order);

        return dto;
    }


    public async Task SetPackageIdsAsync(List<OrderItemGetDto> dtos,int packageId)
    {
        foreach (var dto in dtos)
        {
            var order = await _repository.GetAsync(x => x.Id == dto.Id);

            if (order is null)
                throw new NotFoundException();

            order.PackageId=packageId;

            _repository.Update(order);
        }

        await _repository.SaveChangesAsync();
    }

    private static Func<IQueryable<OrderItem>, IIncludableQueryable<OrderItem, object>> _getWithIncludes(LanguageType language)
    {
        return x => x.Include(x => x.User)
                .Include(x => x.Shop)
                .Include(x => x.Package)
                .Include(x => x.Country).ThenInclude(x => x!.CountryDetails.Where(x => x.LanguageId == (int)language))
                .Include(x => x.Status).ThenInclude(x => x!.StatusDetails.Where(x => x.LanguageId == (int)language));
    }
    private static Func<IQueryable<OrderItem>, IIncludableQueryable<OrderItem, object>> _getWithIncludes()
    {
        return x => x.Include(x => x.User)
                .Include(x => x.Shop)
                .Include(x => x.Package)
                .Include(x => x.Country).ThenInclude(x => x!.CountryDetails)
                .Include(x => x.Status).ThenInclude(x => x!.StatusDetails);
    }

    public async Task<OrderItemCreateDto> GetCreateDtoAsync(OrderItemCreateDto dto, LanguageType language = LanguageType.Azerbaijan)
    {
        var countries = _countryService.GetAll(language);
            
        dto.Countries = countries;
        var userId = _cookieService.GetUserId();

        var user = await _userManager.FindByIdAsync(userId);


        return dto;
    }
    public Task<PaginateDto<OrderItemGetDto>> GetPagesAsync(LanguageType language = LanguageType.Azerbaijan, int page = 1, int limit = 10)
    {
        throw new NotImplementedException();
    }

    public Task<OrderUpdateDto> GetUpdatedDtoAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<OrderBasketDto> GetUserBasketByAsync(int countryId, LanguageType language = LanguageType.Azerbaijan)
    {
        var isExsist = await _countryService.IsExistAsync(countryId);

        if (!isExsist)
            throw new NotFoundException("Bu idli olke tapilmadi");

        var user = await _authService.GetAuthenticatedUserAsync();

        var orders = _repository.GetAll(x => x.CountryId == countryId && x.UserId == user.Id && x.StatusId == (int)StatusName.NotOrdered);

        orders.OrderByDescending(x => x.CreatedAt);
        var dtos = _mapper.Map<List<OrderItemGetDto>>(orders);

        var localPoints =  _localPointService.GetAll(language);
        OrderBasketDto dto = new()
        {
            Orders = dtos,
            SelectedCountryId = countryId,
            SelectedLLocalPointId = user.LocalPointId,
            LocalPoints = localPoints
        };
        return dto;
    }

    public async Task<OrderItemUpdateDto> IncreaseOrderCountAsync(int itemId)
    {
        var order = await _repository.GetAsync(itemId);

        if (order == null)
            throw new NotFoundException("Bu idli baglama tapilmadi");

        order.Count += 1;
        if (order.CountryId == (int)CountryName.Turkiye)
            order.OrderItemTotalPrice = (order.LocalCargoPrice + (order.ItemPrice * order.Count)) * 1.05m;
        else
            order.OrderItemTotalPrice = (order.LocalCargoPrice + (order.ItemPrice * order.Count)) * 1.07m;

        _repository.Update(order);
        await _repository.SaveChangesAsync();

        OrderItemUpdateDto dto = new()
        {
            Count = order.Count,
            OrderTotalPrice = order.OrderItemTotalPrice
        };

        return dto;
    }
    public async Task<OrderItemUpdateDto> DecreaseOrderCountAsync(int itemId)
    {
        var order = await _repository.GetAsync(itemId);

        if (order == null)
            throw new NotFoundException("Bu idli baglama tapilmadi");


        order.Count = order.Count == 1 ? 1 : --order.Count;

        if (order.CountryId == (int)CountryName.Turkiye)
            order.OrderItemTotalPrice = (order.LocalCargoPrice + (order.ItemPrice * order.Count)) * 1.05m;
        else
            order.OrderItemTotalPrice = (order.LocalCargoPrice + (order.ItemPrice * order.Count)) * 1.07m;

        _repository.Update(order);
        await _repository.SaveChangesAsync();

        OrderItemUpdateDto dto = new()
        {
            Count = order.Count,
            OrderTotalPrice = order.OrderItemTotalPrice
        };

        return dto;
    }


    public Task<bool> IsExistAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(OrderUpdateDto dto, ModelStateDictionary ModelState)
    {
        throw new NotImplementedException();
    }

    public async Task<List<OrderItemGetDto>> GetUsersOrdersAsync(string userId)
    {
        var orders = await _repository.GetAll(x => x.UserId == userId,include:_getWithIncludes()).ToListAsync();

        var dtos = _mapper.Map<List<OrderItemGetDto>>(orders);

        return dtos;
    }
}
