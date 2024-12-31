﻿using LimakAz.Domain.Enums;

namespace LimakAz.Persistence.Implementations.Services.UI;

internal class HomeService : IHomeService
{
    private readonly INewsService _newsService;
    private readonly ICertificateService _certificateService;
    private readonly ICountryService _countryService;
    private readonly IShopService _shopService;
    private readonly ISliderService _sliderService;

    public HomeService(INewsService newsService, ICertificateService certificateService, ICountryService countryService, IShopService shopService, ISliderService sliderService)
    {
        _newsService = newsService;
        _certificateService = certificateService;
        _countryService = countryService;
        _shopService = shopService;
        _sliderService = sliderService;
    }

    public async Task<HomeGetDto> GetHomeAsync(LanguageType language = LanguageType.Azerbaijan)
    {
        var news = await _newsService.GetPagesAsync(language, limit: 4);
        var certificates = await _certificateService.GetPagesAsync(language, limit: 6);
        var shops = await _shopService.GetPagesAsync(language, limit :8);
        var sliders = await _sliderService.GetPagesAsync(limit: 5);
        HomeGetDto dto = new()
        {
            News = news,
            Certificates = certificates,
            Shops = shops,
            Sliders = sliders
        };

        return dto;
    }
}
