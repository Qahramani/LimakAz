using LimakAz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;

public class RulesController : Controller
{
    private readonly IContentService _contentService;
    private readonly ICookieService _cookieService;

    public RulesController(IContentService contentService, ICookieService cookieService)
    {
        _contentService = contentService;
        _cookieService = cookieService;
    }

    public IActionResult Terms()
    {

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Questions()
    {
        return View();
    }
}
