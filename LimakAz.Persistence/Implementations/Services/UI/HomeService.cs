using LimakAz.Domain.Enums;

namespace LimakAz.Persistence.Implementations.Services.UI;

internal class HomeService : IHomeService
{
    private readonly INewsService _newsService;
    private readonly ICertificateService _certificateService;
    private readonly ICountryService _countryService;

    public HomeService(INewsService newsService, ICertificateService certificateService, ICountryService countryService)
    {
        _newsService = newsService;
        _certificateService = certificateService;
        _countryService = countryService;
    }

    public async Task<HomeGetDto> GetHomeAsync(LanguageType language = LanguageType.Azerbaijan)
    {
        var news = await _newsService.GetPagesAsync(language, limit: 4);
        var certificates = await _certificateService.GetPagesAsync(language, limit: 6);

        HomeGetDto dto = new()
        {
            News = news,
            Certificates = certificates
        };

        return dto;
    }
}
