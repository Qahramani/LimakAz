using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
public class SliderController : Controller
{
    private readonly ISliderService _sliderService;

    public SliderController(ISliderService sliderService)
    {
        _sliderService = sliderService;
    }

    public async Task<IActionResult> Index()
    {
        var dtos = await _sliderService.GetPagesAsync();

        return View(dtos);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(SliderCreateDto dto)
    {
        var result = await _sliderService.CreateAsync(dto, ModelState);

        if (!result)
        {
            return View(dto);
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var dto = await _sliderService.GetUpdatedDtoAsync(id);

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Update(SliderUpdateDto dto)
    {
        var result = await _sliderService.UpdateAsync(dto, ModelState);
        if (!result)
        {
            return View(dto);

        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _sliderService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }
}
