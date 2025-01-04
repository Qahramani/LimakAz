namespace LimakAz.Application.Interfaces.Services;

public interface ICitizenShipService
{
    List<CitizenShipGetDto> GetAllAsync(LanguageType languageType = LanguageType.Azerbaijan);
}
