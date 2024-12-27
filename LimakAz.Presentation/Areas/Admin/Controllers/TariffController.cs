using LimakAz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
public class TariffController : Controller
{
    private readonly ITariffService _tariffService;

    public TariffController(ITariffService tariffService)
    {
        _tariffService = tariffService;
    }

    public async Task<IActionResult> Index(int page = 1)
    {
        var tariffs = await _tariffService.GetPagesAsync(page: 1, limit: 3);

        return View(tariffs);
    }
    public IActionResult Create()
    {
        ViewData["Title"] = "Aze";
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(int id)
    {
        return View();
    }
}
