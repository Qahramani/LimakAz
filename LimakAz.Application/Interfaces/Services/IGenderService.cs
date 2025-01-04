namespace LimakAz.Application.Interfaces.Services;

public interface IGenderService
{
    List<GenderGetDto> GetAllAsync(LanguageType language = LanguageType.Azerbaijan);
}
