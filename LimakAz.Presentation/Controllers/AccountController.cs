﻿using LimakAz.Application.DTOs;
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

    public AccountController(IAuthService authService, ICookieService cookieService)
    {
        _authService = authService;
        _cookieService = cookieService;
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
            return View(dto);
        }

        return RedirectToAction("index", "userpanel");
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

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> VerifyEmail(string token, string email)
    {
       var result = await _authService.EmailVerificationAsync(token, email);

        if (!result)
        {
            return View("EmailVerificationFailure");
        }

        return View("EmailVerificationSuccess");
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
