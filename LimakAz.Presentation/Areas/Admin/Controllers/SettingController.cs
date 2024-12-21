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

    public IActionResult Update(SettingUpdateDto dto)
    {
        return View();
    }
}
