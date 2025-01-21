using LimakAz.Application.Interfaces.Services.Generic;


namespace LimakAz.Application.Interfaces.Services;

public interface IOrderService : IGetService<OrderGetDto>, IModifyService<OrderCreateDto, OrderUpdateDto>
{
    Task<OrderCreateDto> GetCreateDtoAsync(OrderCreateDto dto, LanguageType language = LanguageType.Azerbaijan);
    Task<List<OrderGetDto>> GetUserOrdersByCountryId(int countryId);
    Task<int> IncreaseOrderCount(int itemId);
    Task<int> DecreaseOrderCount(int itemId);

}