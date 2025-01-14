using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using LimakAz.Domain.Entities;
using LimakAz.Presentation.Extentions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;

public class AccountController : Controller
{
    private readonly IAuthService _authService;
    private readonly ICookieService _cookieService;
    private readonly UserManager<AppUser> _userManager;

    public AccountController(IAuthService authService, ICookieService cookieService, UserManager<AppUser> usesrManager)
    {
        _authService = authService;
        _cookieService = cookieService;
        _userManager = usesrManager;
    }

    public async Task<IActionResult> Register()
    {
        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        var dto = _authService.GetRegisterDto(new RegisterDto(), language);

        return View(dto);
    }

    public IActionResult Login()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Login(LoginDto dto)
    {

        var result = await _authService.LoginAsync(dto, ModelState);

        if (!result)
        {
            return PartialView("_LoginModalPartial", dto);
        }

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var result = await _authService.RegisterAsync(dto, ModelState);

        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        if (!result)
        {
            dto = _authService.GetRegisterDto(dto, language);
            return View(dto);
        }

        return View("ConfirmEmail");
    }

    public async Task<IActionResult> Logout()
    {
        await _authService.LogoutAsync();

        var returlUrl = Request.GetReturnUrl();

        return Redirect(returlUrl);
    }

    public async Task<IActionResult> VerifyEmail(string token, string email)
    {
        if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(email))
        {
            return BadRequest("Token or email is invalid");
        }

        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            return NotFound("User not found");
        }

        var result = await _userManager.ConfirmEmailAsync(user, token);

        if (!result.Succeeded)
        {
            return View("EmailVerificationFailure", result.Errors);
        }

        return View("EmailVerificationSuccess", user.Firstname);
    }

    public IActionResult ForgotPassword()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordDto dto)
    {
        var result = await _authService.ResetPasswordConfirmationAsync(dto, ModelState);

        if (!result)
            return View(dto);

        return View("ResetPasswordConfirmation");
    }

    public IActionResult ResetPassword(string token)
    {
        if (string.IsNullOrEmpty(token))
            return BadRequest();

        ResetPasswordDto dto = new()
        {
            Token = token
        };
        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> ResetPassword(ResetPasswordDto dto)
    {
        var result = await _authService.ResetPasswordAsync(dto, ModelState);

        if (!result)
            return View(dto);

        return View("ResetPasswordSuccess");
    }
}
