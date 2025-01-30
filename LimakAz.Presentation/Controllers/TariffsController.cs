using LimakAz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;
public class TariffsController : Controller
{
    private readonly ITariffService _tariffService;
    private readonly ICookieService _cookieService;
    public TariffsController(ITariffService tariffService, ICookieService cookieService)
    {
        _tariffService = tariffService;
        _cookieService = cookieService;
    }

    public async Task<IActionResult> Index()
    {
        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        var dtos = await _tariffService.GetTariffsUiDtosAsync(language);

        return View(dtos);
    }
}
