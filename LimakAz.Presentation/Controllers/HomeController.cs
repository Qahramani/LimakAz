using LimakAz.Application.Interfaces.Services;
using LimakAz.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LimakAz.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly IHomeService _homeService;
    private readonly ICookieService _cookieService;
    private readonly IPaymentService _paymentService;
    public HomeController(IHomeService homeService, ICookieService cookieService, IPaymentService paymentService)
    {
        _homeService = homeService;
        _cookieService = cookieService;
        _paymentService = paymentService;
    }

    public async Task<IActionResult> Index()
    {
        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        var dto = await _homeService.GetHomeAsync(language);

        return View(dto);
    }

    public async Task<IActionResult> TestPayment()
    {
        var result = await _paymentService.CreateAsync(new() { Amount=100, Description="Limak sifaris"});

        return Json(result);
    }

}
