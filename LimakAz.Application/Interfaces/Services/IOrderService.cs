using LimakAz.Application.Interfaces.Services.Generic;


namespace LimakAz.Application.Interfaces.Services;

public interface IOrderService : IGetService<OrderGetDto>, IModifyService<OrderCreateDto, OrderUpdateDto>
{
    Task<OrderCreateDto> GetCreateDtoAsync(OrderCreateDto dto, LanguageType language = LanguageType.Azerbaijan);
    Task<OrderBasketDto> GetOrderBasketByCountryIdAsync(int countryId);
    Task<OrderItemUpdateDto> IncreaseOrderCountAsync(int itemId);
    Task<OrderItemUpdateDto> DecreaseOrderCountAsync(int itemId);
    Task<string> PayOrdersAsync(List<int> orderIds);
    Task<List<PackageDto>> GetUserPackagesAsync(int statusId, int countryId = 4,  LanguageType language = LanguageType.Azerbaijan);

}