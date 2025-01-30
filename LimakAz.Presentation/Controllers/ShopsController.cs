using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using LimakAz.Persistence.Contexts;
using Microsoft.AspNetCore.Authorization;
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

    public async Task<IActionResult> Index(int countryId = 0, int categoryId = 0, int page = 1)
    {
        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        var dto = await _shopService.GetFileteredShopsAsync(countryId, categoryId, page,language);

        ViewBag.CountryId = countryId;
        ViewBag.CategoryId = categoryId;
        ViewBag.Page = page;

        return View(dto);
    }

    [HttpGet]
    public async Task<IActionResult> GetShops(int categoryId, int countryId)
    {
        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        var dtos = await _shopService.GetFileteredShopsAsync(categoryId, countryId, (int)language);

        return PartialView("_ShopsPartial",dtos);
    }



}
