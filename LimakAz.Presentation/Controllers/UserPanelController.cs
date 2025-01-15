using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;

public class UserPanelController : Controller
{
    private readonly IUserPanelService _userPanelService;
    private readonly ICookieService _cookieService;
    public UserPanelController(IUserPanelService userPanelService, ICookieService cookieService)
    {
        _userPanelService = userPanelService;
        _cookieService = cookieService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Settings()
    {
        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        var dto = await _userPanelService.GetUserUpdateDtoAsync(language);

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProfile(UserProfileUpdateDto dto)
    {
        var result = await _userPanelService.UpdateProfileAsync(dto, ModelState);

        if (!result)
        {
            UserSettingDto settingDto = new()
            {
                UserProfileInfo = dto
            };

            return View("Settings", settingDto);
        }

        //TempData["SuccessMessage"] = "Password updated successfully!";

        return RedirectToAction(nameof(Settings));
    }

    [HttpPost]
    public async Task<IActionResult> UpdatePassword(UserPasswordUpdateDto dto)
    {
        var result = await _userPanelService.UpdatePasswordAsync(dto, ModelState);

        if (!result)
        {
            

            return View("Settings", dto);
        }

        //TempData["SuccessMessage"] = "Password updated successfully!";

        return RedirectToAction(nameof(Settings));
    }

}

