﻿using LimakAz.Application.Interfaces.Helpers;
using LimakAz.Application.Interfaces.Services.External;
using LimakAz.Domain.Enums;
using LimakAz.Persistence.Helpers;
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
    private readonly IValidationMessageProvider _localizer;
    private readonly IStatusService _statusService;
    private readonly UserManager<AppUser> _userManager;
    private readonly ICookieService _cookieService;
    private readonly IAuthService _authService;
    private readonly IPaymentService _paymentService;
    private readonly ICurrencyService _currencyService;
    public OrderService(IOrderRepository repository, IMapper mapper, ICountryService countryService, ILocalPointService localPointService, ITariffService tariffService, IValidationMessageProvider localizer, IStatusService statusService, UserManager<AppUser> userManager, ICookieService cookieService, IAuthService authService, IPaymentService paymentService, ICurrencyService currencyService)
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
        _paymentService = paymentService;
        _currencyService = currencyService;
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
        {
            order.OrderTotalPrice = (dto.LocalCargoPrice + (dto.ItemPrice * dto.Count)) * 1.05m;
        }
        else
        {

            order.OrderTotalPrice = (dto.LocalCargoPrice + (dto.ItemPrice * dto.Count)) * 1.07m;
        }

        
        
        order.StatusId = (int)StatusName.NotOrdered;
        order.NO = Helper.GenerateOrderNO();

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
    public List<OrderGetDto> GetAll(LanguageType language = LanguageType.Azerbaijan)
    {
        throw new NotImplementedException();
    }

    public async Task<OrderGetDto> GetAsync(int id, LanguageType language = LanguageType.Azerbaijan)
    {
        var order = await _repository.GetAsync(x => x.Id == id, _getWithIncludes(language));

        if (order == null)
            throw new NotFoundException();

        var dto = _mapper.Map<OrderGetDto>(order);

        return dto;
    }

    private static Func<IQueryable<Order>, IIncludableQueryable<Order, object>> _getWithIncludes(LanguageType language)
    {
        return x => x.Include(x => x.User)
                .Include(x => x.Country).ThenInclude(x => x.CountryDetails.Where(x => x.LanguageId == (int)language))
                .Include(x => x.Status).ThenInclude(x => x.StatusDetails.Where(x => x.LanguageId == (int)language))
                .Include(x => x.Shop)
                .Include(x => x.LocalPoint).ThenInclude(x => x.LocalPointDetails.Where(x => x.LanguageId == (int)language));
    }
    private static Func<IQueryable<Order>, IIncludableQueryable<Order, object>> _getWithIncludes()
    {
        return x => x.Include(x => x.User)
                .Include(x => x.Country).ThenInclude(x => x.CountryDetails)
                .Include(x => x.Status).ThenInclude(x => x.StatusDetails)
                .Include(x => x.Shop)
                .Include(x => x.LocalPoint).ThenInclude(x => x.LocalPointDetails);
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

    public async Task<OrderBasketDto> GetOrderBasketByCountryIdAsync(int countryId)
    {
        var isExsist = await _countryService.IsExistAsync(countryId);

        if (!isExsist)
            throw new NotFoundException("Bu idli olke tapilmadi");

        var user = await _authService.GetAuthenticatedUserAsync();

        var orders = _repository.GetAll(x => x.CountryId == countryId && x.UserId == user.Id && x.StatusId == (int)StatusName.NotOrdered);

        orders.OrderByDescending(x => x.CreatedAt);
        var dtos = _mapper.Map<List<OrderGetDto>>(orders);

        OrderBasketDto dto = new()
        {
            Orders = dtos,
            SelectedCountryId = countryId
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
            order.OrderTotalPrice = (order.LocalCargoPrice + (order.ItemPrice * order.Count)) * 1.05m;
        else
            order.OrderTotalPrice = (order.LocalCargoPrice + (order.ItemPrice * order.Count)) * 1.07m;

        _repository.Update(order);
        await _repository.SaveChangesAsync();

        OrderItemUpdateDto dto = new()
        {
            Count = order.Count,
            OrderTotalPrice = order.OrderTotalPrice
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
            order.OrderTotalPrice = (order.LocalCargoPrice + (order.ItemPrice * order.Count)) * 1.05m;
        else
            order.OrderTotalPrice = (order.LocalCargoPrice + (order.ItemPrice * order.Count)) * 1.07m;

        _repository.Update(order);
        await _repository.SaveChangesAsync();

        OrderItemUpdateDto dto = new()
        {
            Count = order.Count,
            OrderTotalPrice = order.OrderTotalPrice
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

    public async Task<string> PayOrdersAsync(List<int> orderIds)
    {
        var user = await _authService.GetAuthenticatedUserAsync();

        if (orderIds.Count == 0)
            throw new EmptyBasketException();

        List<Order> orders = await  _repository.GetAll(x => orderIds.Contains(x.Id) ,include : _getWithIncludes()).ToListAsync();
        var countryId = orders.FirstOrDefault()?.CountryId;

        foreach (var order in orders)
        {
            if (order.UserId != user.Id || order.CountryId != countryId || order.Status?.Id != (int)StatusName.NotOrdered)
                throw new NotFoundException($"{order.Id}li sifaris tapilmadi");
        }

        decimal totalPrice = 0;

        orders.ForEach(x => totalPrice += x.OrderTotalPrice);

        decimal totalPriceInAZN = 0;

        if(countryId == 4)
            totalPriceInAZN = await _currencyService.ConvertAsync( totalPrice, "TRY", "AZN");
        else
            totalPriceInAZN = await _currencyService.ConvertAsync( totalPrice, "USD", "AZN");

        var result = await _paymentService.CreateAsync(new()
        {
            Amount = totalPriceInAZN,
            Description = "Limak odenis"
        });

        string url = $"{result.Order.HppUrl}?id={result.Order.Id}&password={result.Order.Password}";

        return url;
    }

    public async Task<List<PackageDto>> GetUserPackagesAsync(int statusId, int countryId = 4,  LanguageType language = LanguageType.Azerbaijan)
    {
        var isExist = await _countryService.IsExistAsync(countryId);

        if (!isExist)
            throw new NotFoundException("Bu idli olke tapilmadi");

        isExist = await _statusService.IsExistAsync(statusId);

        if(statusId != 0 && !isExist)
            throw new NotFoundException("Bu idli status tapilmadi");

        var user = await _authService.GetAuthenticatedUserAsync();

        var orders = _repository.GetAll(x => x.UserId == user.Id && x.CountryId == countryId && x.StatusId != (int)StatusName.NotOrdered,include : _getWithIncludes(language));

        if (statusId != 0)
            orders = orders.Where(x => x.StatusId == statusId);

        List<PackageDto> dtos = new List<PackageDto>();

        foreach (var order in orders)
        {
            PackageDto dto = new()
            {
                NO = order.NO,
                Weigth = order.Weight,
                CreatedAt = order.CreatedAt,
                Status = order.Status?.StatusDetails.FirstOrDefault()?.Name,
                Price = order.OrderTotalPrice
            };

            dtos.Add(dto);
        }
        
        return dtos;
    }
}
