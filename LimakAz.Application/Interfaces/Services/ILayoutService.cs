using LimakAz.Application.DTOs.LanguageDtos;

namespace LimakAz.Application.Interfaces.Services;

public interface ILayoutService
{
    Task<LanguageGetDto> GetSelectedLanguageAsync();

}
