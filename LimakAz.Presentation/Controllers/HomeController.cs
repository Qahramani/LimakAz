using LimakAz.Application.Exceptions;
using LimakAz.Application.Interfaces.Services;
using LimakAz.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
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

    public IActionResult Error(string message, int statusCode)
    {
        ViewData["Message"] = message;
        ViewData["StatusCode"]=statusCode;
        return View();
    }



}
