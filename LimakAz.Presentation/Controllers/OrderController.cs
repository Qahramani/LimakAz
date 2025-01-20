using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    private readonly ICookieService _cookieService;

    public OrderController(IOrderService orderService, ICookieService cookieService)
    {
        _orderService = orderService;
        _cookieService = cookieService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFromLink(string orderLink = "")
    {
        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        var dto = await _orderService.GetCreateDtoAsync( new() { Link = orderLink},language);

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(OrderCreateDto dto)
    {
        var result = await _orderService.CreateAsync(dto, ModelState);

        if (!result)
        {
            var language = await _cookieService.GetSelectedLanguageTypeAsync();

            dto = await _orderService.GetCreateDtoAsync(dto, language);

            return View(result);
        }

        return View(dto);
    }
}
