using LimakAz.Application.Interfaces.Services.Generic;

namespace LimakAz.Application.Interfaces.Services;

public interface IShopService : IGetService<ShopGetDto>, IModifyService<ShopCreateDto, ShopUpdateDto>
{
    ShopCreateDto GetCreateDto(ShopCreateDto dto);
}