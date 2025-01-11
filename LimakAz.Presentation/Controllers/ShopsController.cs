using LimakAz.Application.Interfaces.Services;
using LimakAz.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;

public class ShopsController : Controller
{
    private readonly IShopService _shopService;
    private readonly ICookieService _cookieService;
    public ShopsController(IShopService shopService, ICookieService cookieService)
    {
        _shopService = shopService;
        _cookieService = cookieService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetShops(int categoryId, int countryId)
    {
        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        var dtos = await _shopService.GetFileteredShopsAsync(categoryId, countryId, language);

        return PartialView("_ShopsPartial",dtos);
    }



}
