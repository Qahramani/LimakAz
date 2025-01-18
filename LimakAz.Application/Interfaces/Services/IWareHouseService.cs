using LimakAz.Application.Interfaces.Services.Generic;

namespace LimakAz.Application.Interfaces.Services;

public interface IAddressLineService : IGetService<AddressLineGetDto>,IModifyService<AddressLineCreateDto,AddressLineUpdateDto>
{
    Task<Dictionary<string, string>> GetDictionaryAsync(int languageId);

}