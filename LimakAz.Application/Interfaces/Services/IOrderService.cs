using LimakAz.Application.Interfaces.Services.Generic;


namespace LimakAz.Application.Interfaces.Services;

public interface IOrderService : IGetService<OrderItemGetDto>, IModifyService<OrderItemCreateDto, OrderUpdateDto>
{
    Task<OrderItemCreateDto> GetCreateDtoAsync(OrderItemCreateDto dto, LanguageType language = LanguageType.Azerbaijan);
    Task<OrderBasketDto> GetUserBasketByAsync(int countryId, LanguageType language = LanguageType.Azerbaijan);
    Task<OrderItemUpdateDto> IncreaseOrderCountAsync(int itemId);
    Task<OrderItemUpdateDto> DecreaseOrderCountAsync(int itemId);
    Task<List<OrderItemGetDto>> GetUsersOrdersAsync(string userId);
    Task SetPackageIdsAsync(List<OrderItemGetDto> dtos, int packageId);

}