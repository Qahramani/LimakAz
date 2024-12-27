using LimakAz.Application.DTOs;

namespace LimakAz.Application.Interfaces.Services;

public interface IHomeService
{
    Task<HomeGetDto> GetHomeAsync(LanguageType language = LanguageType.Azerbaijan);
}
