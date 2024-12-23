using LimakAz.Application.DTOs.LanguageDtos;
using LimakAz.Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace LimakAz.Persistence.Implementations.Services;

internal class LayoutService : ILayoutService
{
    private readonly ICookieService _cookieService;
    private readonly ISettingService _settingService;

    public LayoutService(ICookieService cookieService, ISettingService settingService)
    {
        _cookieService = cookieService;
        _settingService = settingService;
    }

    public async Task<LanguageGetDto> GetSelectedLanguageAsync()
    {
        return await _cookieService.GetSelectedLanguageAsync();
    }

    public async Task<Dictionary<string, string>> GetSettingsDictionary()
    {
        var language = await GetSelectedLanguageAsync();

        return await _settingService.GetSettingDictionaryAsync(language.Id);
    }
}
