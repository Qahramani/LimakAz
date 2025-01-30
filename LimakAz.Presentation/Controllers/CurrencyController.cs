using LimakAz.Application.Interfaces.Services.External;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;
public class CurrencyController : Controller
{
    private readonly ICurrencyService _currencyService;

    public CurrencyController(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }

    public async Task<IActionResult> Convert(decimal amount, string from, string to)
    {
        var convertedAmount = await _currencyService.ConvertAsync(amount, from, to);

        return Ok(new { convertedAmount });

    }
}
