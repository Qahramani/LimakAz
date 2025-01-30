using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using LimakAz.Application.Interfaces.Services.External;
using LimakAz.Application.Interfaces.Services.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;
public class CalculatorController : Controller
{
    private readonly ICalculatorService _calculatorService;
    private readonly ICookieService _cookieService;

    public CalculatorController(ICalculatorService calculatorService, ICookieService cookieService)
    {
        _calculatorService = calculatorService;
        _cookieService = cookieService;
    }

    public async Task<IActionResult> Index()
    {
        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        var dto =  _calculatorService.GetCalculatorDto(language);

        return View(dto);
    }
    [HttpPost]
    public async Task<IActionResult> Index(CalculatorDto dto)
    {
        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        var resultDto = await _calculatorService.CalculateAsync(dto);

        return View(resultDto);
    }
}
