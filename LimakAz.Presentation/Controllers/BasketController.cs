using LimakAz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;

public class BasketController : Controller
{
    private readonly IOrderService _orderService;

    public BasketController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<IActionResult> Index(int countryId = 4)
    {
        var orders = await _orderService.GetUserOrdersByCountryId(countryId);

        return View(orders);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteFromBasket(int itemId)
    {
        await _orderService.DeleteAsync(itemId);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public JsonResult IncreaseCount(int itemId)
    {
        var newCount = _orderService.IncreaseOrderCount(itemId);
       
        return Json(new { newCount });
    }

    [HttpPost]
    public JsonResult DecreaseCount(int itemId)
    {
        var newCount = _orderService.DecreaseOrderCount(itemId);
        
        return Json(new { newCount });
    }

}
