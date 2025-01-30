using LimakAz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;
public class ContactController : Controller
{
    private readonly ILocalPointService _localPointService;
    private readonly ICookieService _cookieService;
    public ContactController(ILocalPointService localPointService, ICookieService cookieService)
    {
        _localPointService = localPointService;
        _cookieService = cookieService;
    }

    public async Task<IActionResult> Index()
    {
        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        var points = _localPointService.GetAll(language);

        return View(points);
    }
}
