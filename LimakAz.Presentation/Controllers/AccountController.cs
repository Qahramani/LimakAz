using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;

public class AccountController : Controller
{
    private readonly IAuthService _authService;
    private readonly ICookieService _cookieService;

    public AccountController(IAuthService authService, ICookieService cookieService)
    {
        _authService = authService;
        _cookieService = cookieService;
    }

    public async Task<IActionResult> Register()
    {
        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        var dto = await _authService.GetRegisterDtoAsync(new RegisterDto(), language);

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var result = await _authService.RegisterAsync(dto, ModelState);

        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        if (!result)
        {
            dto = await _authService.GetRegisterDtoAsync(dto, language);
            return View(dto);
        }

        return RedirectToAction("Index", "Home");
    }
}
