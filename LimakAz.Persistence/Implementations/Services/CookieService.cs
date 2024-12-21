using LimakAz.Application.DTOs.LanguageDtos;
using LimakAz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace LimakAz.Persistence.Implementations.Services;

internal class CookieService : ICookieService
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ILanguageService _languageService;

    public CookieService(IHttpContextAccessor contextAccessor, ILanguageService languageService)
    {
        _contextAccessor = contextAccessor;
        _languageService = languageService;
    }

    public async Task<LanguageGetDto> GetSelectedLanguageAsync()
    {
        var culture = _contextAccessor.HttpContext?.Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];
        var isoCode = culture?.Substring(culture.LastIndexOf('=') + 1) ?? "az";
        var selectedLanguage = await _languageService.GetLanguageAsync(x => x.IsoCode == isoCode);

        return selectedLanguage;
    }
}
