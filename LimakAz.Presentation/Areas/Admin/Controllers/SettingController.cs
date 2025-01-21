using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using LimakAz.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin,Moderator")]
public class SettingController : Controller
{
    private readonly ISettingService _settingService;

    public SettingController(ISettingService settingService)
    {
        _settingService = settingService;
    }

    public IActionResult Index()
    {
        var settings =   _settingService.GetAll();

        return View(settings);
    }


    public async Task<IActionResult> Update(int id)
    {
        var setting = await _settingService.GetUpdatedDtoAsync(id);

        return View(setting);
    }

    [HttpPost]
    public async Task<IActionResult> Update(SettingUpdateDto dto)
    {
        var result = await _settingService.UpdateAsync(dto, ModelState);

        if(result is false)
        {
            return View(dto);
        }

        return RedirectToAction(nameof(Index));
    }
}
