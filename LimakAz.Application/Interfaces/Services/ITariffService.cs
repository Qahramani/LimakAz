using LimakAz.Application.Interfaces.Services.Generic;

namespace LimakAz.Application.Interfaces.Services;

public interface ITariffService : IGetService<TariffGetDto>, IModifyService<TariffCreateDto,TariffUpdateDto>
{
    Task<List<TariffGetDto>> GetTariffsByCountry(int countryId, LanguageType language = LanguageType.Azerbaijan);
    Task<List<TariffUiGetDto>> GetTariffsUiDtosAsync(LanguageType language = LanguageType.Azerbaijan);
}
