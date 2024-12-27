using LimakAz.Domain.Enums;

namespace LimakAz.Persistence.Implementations.Services.UI;

internal class HomeService : IHomeService
{
    private readonly INewsService _newsService;

    public HomeService(INewsService newsService)
    {
        _newsService = newsService;
    }

    public async Task<HomeGetDto> GetHomeAsync(LanguageType language = LanguageType.Azerbaijan)
    {
       var news = await _newsService.GetPagesAsync(language,limit : 4);

        HomeGetDto dto = new()
        {
            News = news
        };

        return dto;
    }
}
