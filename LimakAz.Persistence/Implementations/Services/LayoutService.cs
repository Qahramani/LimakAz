using LimakAz.Application.DTOs.LanguageDtos;
using LimakAz.Application.Interfaces.Services;

namespace LimakAz.Persistence.Implementations.Services;

internal class LayoutService : ILayoutService
{
    private readonly ICookieService _cookieService;

    public LayoutService(ICookieService cookieService)
    {
        _cookieService = cookieService;
    }

    public async Task<LanguageGetDto> GetSelectedLanguageAsync()
    {
        return await _cookieService.GetSelectedLanguageAsync();
    }
}
