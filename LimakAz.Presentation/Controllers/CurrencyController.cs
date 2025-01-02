using LimakAz.Application.Interfaces.Services.External;
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
        var rates = await _currencyService.GetExchangeRatesAsync();

        decimal convertedAmount;

        if (from == "AZN")
        {
            convertedAmount = amount / rates[to];

            return Ok(new { convertedAmount });
        }

        if (to == "AZN")
        {
            convertedAmount = amount * rates[from];
            return Ok(new { convertedAmount });
        }

        if (!rates.ContainsKey(from) || !rates.ContainsKey(to))
        {
            return BadRequest("Invalid currency codes.");
        }

        decimal fromRate = rates[from];
        decimal toRate = rates[to];
         convertedAmount = (amount / fromRate) * toRate;

        return Ok(new { convertedAmount });

    }
}
