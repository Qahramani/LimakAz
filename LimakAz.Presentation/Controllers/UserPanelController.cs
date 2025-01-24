﻿using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;

public class UserPanelController : Controller
{
    private readonly IUserPanelService _userPanelService;
    private readonly ICookieService _cookieService;
    private readonly IAddressLineService _addressLineService;
    private readonly IOrderService _orderService;
    public UserPanelController(IUserPanelService userPanelService, ICookieService cookieService, IAddressLineService addressLineService, IOrderService orderService)
    {
        _userPanelService = userPanelService;
        _cookieService = cookieService;
        _addressLineService = addressLineService;
        _orderService = orderService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> AbroadAddresses()
    {
        var dictionary = await _addressLineService.GetDictionaryAsync(1);

        return View(dictionary);
    }
    public async Task<IActionResult> UpdateProfile()
    {
        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        var dto = await _userPanelService.GetUserProfileUpdateDtoAsync(language);

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProfile(UserProfileUpdateDto dto)
    {
        var result = await _userPanelService.UpdateProfileAsync(dto, ModelState);

            var language = await _cookieService.GetSelectedLanguageTypeAsync();

            var profileDto = await _userPanelService.GetUserProfileUpdateDtoAsync(language);
            
        if (!result)
        {

            return View(profileDto);
        }

        ViewBag.SuccessMessage = "Profile Info updated successfully!";

        return View(profileDto);
    }

    public IActionResult UpdatePassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdatePassword(UserPasswordUpdateDto dto)
    {
        var result = await _userPanelService.UpdatePasswordAsync(dto, ModelState);

        if (!result)
        {
            return View(dto);
        }

        ViewBag.SuccessMessage = "Password updated successfully!";

        return View();
    }

    public async Task<IActionResult> Packages(int countryId = 4, int status = 0)
    {
        var packages = await _orderService.GetUserPackagesAsync(status, countryId);

        return View(packages);
    }

}

