using LimakAz.Application.Interfaces.Services.Generic;
using LimakAz.Domain.Enums;

namespace LimakAz.Application.Interfaces.Services;

public interface IShopService : IGetService<ShopGetDto>, IModifyService<ShopCreateDto, ShopUpdateDto>
{
    ShopCreateDto GetCreateDto(ShopCreateDto dto);
    Task<ShopPageDto> GetFileteredShopsAsync(int countryId, int categoryId,int page , LanguageType language = LanguageType.Azerbaijan);
}