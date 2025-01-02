using LimakAz.Application.Interfaces.Services.External;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;

public class CalculatorController : Controller
{
    private readonly ICurrencyService _currencyService;

    public CalculatorController(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _currencyService.GetCurrencyCoefficientAsync("USD");

        return View();
    }
}
