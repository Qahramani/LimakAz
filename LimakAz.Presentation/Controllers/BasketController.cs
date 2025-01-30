using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using LimakAz.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;
[Authorize(Roles = "Member")]
public class BasketController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IPaymentService _paymentService;
    private readonly IPackageService _packageService;
    private readonly ICookieService _cookieService;
    public BasketController(IOrderService orderService, IPaymentService paymentService, IPackageService packageService, ICookieService cookieService)
    {
        _orderService = orderService;
        _paymentService = paymentService;
        _packageService = packageService;
        _cookieService = cookieService;
    }

    public async Task<IActionResult> Index(int countryId = 1)
    {
        var language = await _cookieService.GetSelectedLanguageTypeAsync();
        var basket = await _orderService.GetUserBasketByAsync(countryId,language);

        return View(basket);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteFromBasket(int itemId)
    {
        await _orderService.DeleteAsync(itemId);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<JsonResult> IncreaseCount(int itemId)
    {
        var result = await _orderService.IncreaseOrderCountAsync(itemId);

        return Json(result);
    }

    [HttpPost]
    public async Task<JsonResult> DecreaseCount(int itemId)
    {
        var result = await _orderService.DecreaseOrderCountAsync(itemId);

        return Json(result);
    }

    [HttpPost]
    public async Task<IActionResult> SubmitOrderIds(OrderBasketDto dto)
    {
        var url = await _packageService.CreatePacakageAsync(dto);

        if (string.IsNullOrEmpty(url))
            RedirectToAction(nameof(Index));

        return Redirect(url);
    }


    
}
