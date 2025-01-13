using LimakAz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace LimakAz.Presentation.Controllers;

public class NewsController : Controller
{
    private readonly INewsService _newsService; 
    private readonly ICookieService _cookieService;
    public NewsController(INewsService newsService, ICookieService cookieService)
    {
        _newsService = newsService;
        _cookieService = cookieService;
    }

    public async Task<IActionResult> Index(int page = 1)
    {
        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        var news = await _newsService.GetPagesAsync(language, page, 4);

        return View(news);
    }
    public async Task<IActionResult> Details(int id)
    {
        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        var news = await _newsService.GetNewsDetailsUiAsync(id, language);

        return View(news);
    }
}
