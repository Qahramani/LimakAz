using LimakAz.Application.Interfaces.Services;
using LimakAz.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LimakAz.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly IHomeService _homeService;
    private readonly ICookieService _cookieService;

    public HomeController(IHomeService homeService, ICookieService cookieService)
    {
        _homeService = homeService;
        _cookieService = cookieService;
    }

    public async Task<IActionResult> Index()
    {
        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        var dto = await _homeService.GetHomeAsync(language);

        return View(dto);
    }

}
