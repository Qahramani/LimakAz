namespace LimakAz.Application.Interfaces.Services;

public interface IUserPositionService
{
    List<UserPositionGetDto> GetAllAsync(LanguageType languageType = LanguageType.Azerbaijan);
}
