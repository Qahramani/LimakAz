using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using LimakAz.Application.Interfaces.Services.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;
public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    private readonly ICookieService _cookieService;
    private readonly IPaymentService _paymentService;
    public OrderController(IOrderService orderService, ICookieService cookieService, IPaymentService paymentService)
    {
        _orderService = orderService;
        _cookieService = cookieService;
        _paymentService = paymentService;
    }

    [HttpGet]
    [HttpPost]
    public async Task<IActionResult> CreateFromLink(string? orderLink = "")
    {
        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        var dto = await _orderService.GetCreateDtoAsync(new() { Link = orderLink }, language);

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(OrderItemCreateDto dto)
    {
        var result = await _orderService.CreateAsync(dto, ModelState);

        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        dto = await _orderService.GetCreateDtoAsync(dto, language);

        if (!result)
        {

            return View("CreateFromLink", dto);
        }
        ViewBag.SuccessMessage = "Item successfully added to the basket!";
        return View("CreateFromLink", dto);
    }
    public async Task<IActionResult> CheckPayment(PaymentCheckDto dto)
    {
        var result = await _paymentService.ConfirmPaymentAsync(dto);

        if (!result)
        {
            return RedirectToAction("Index","Basket");
        }

        return View();
    }
}
