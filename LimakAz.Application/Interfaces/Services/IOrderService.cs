using LimakAz.Application.Interfaces.Services.Generic;


namespace LimakAz.Application.Interfaces.Services;

public interface IOrderService : IGetService<OrderGetDto>, IModifyService<OrderCreateDto, OrderUpdateDto>
{
    Task<OrderCreateDto> GetCreateDtoAsync(OrderCreateDto dto, LanguageType language = LanguageType.Azerbaijan);
    Task<OrderBasketDto> GetOrderBasketByCountryIdAsync(int countryId);
    Task<OrderItemUpdateDto> IncreaseOrderCountAsync(int itemId);
    Task<OrderItemUpdateDto> DecreaseOrderCountAsync(int itemId);
    Task<decimal> PayOrdersAsync(List<int> orderIds);

}