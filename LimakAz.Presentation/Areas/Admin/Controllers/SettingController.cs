using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using LimakAz.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Areas.Admin.Controllers;

[Area("admin")]
public class SettingController : Controller
{
    private readonly ISettingService _settingService;

    public SettingController(ISettingService settingService)
    {
        _settingService = settingService;
    }

    public async Task<IActionResult> Index()
    {
        var settings = await _settingService.GettAllAsync();

        return View(settings);
    }


    public async Task<IActionResult> Update(int id)
    {
        var setting = await _settingService.GetUpdateDtoAsync(id);

        return View(setting);
    }

    [HttpPost]
    public async Task<IActionResult> Update(SettingUpdateDto dto)
    {
        var result = await _settingService.UpdateAsync(dto, ModelState);

        if(result is false)
            return View(result);

        return Redirect(nameof(Index));
    }
}
