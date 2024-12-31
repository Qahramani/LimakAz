using LimakAz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;

public class ShopsController : Controller
{
    private readonly IShopService _shopService;

    public ShopsController(IShopService shopService)
    {
        _shopService = shopService;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult GetFilteredShops(int? countryId, int? categoryId)
    {
        // Fetch all shops initially
        var shops = _shopService.GetAll();

        // Apply country filter
        if (countryId.HasValue)
        {
            shops = shops.Where(s => s.CountryId == countryId.Value).ToList();
        }

        // Apply category filter
        if (categoryId.HasValue)
        {
            shops = shops.Where(s => s.Categories.Any(c => c.CategoryId == categoryId.Value)).ToList();
        }

        // Return the filtered shops as JSON
        return Json(new
        {
            success = true,
            data = shops.Select(s => new
            {
                s.ShopId,
                s.Name,
                s.ImageUrl,
                s.Url,
                s.CountryId,
                Categories = s.Categories.Select(c => c.CategoryId)
            })
        });
    }

}
