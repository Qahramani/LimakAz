using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
public class LocalPointController : Controller
{

    private readonly ILocalPointService _pointService;

    public LocalPointController(ILocalPointService pointService)
    {
        _pointService = pointService;
    }

    public IActionResult Index()
    {
        var dtos = _pointService.GetAll();

        return View(dtos);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(LocalPointCreateDto dto)
    {
        var result = await _pointService.CreateAsync(dto, ModelState);

        if (!result)
        {
            return View(dto);
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var dto = await _pointService.GetUpdatedDtoAsync(id);

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Update(LocalPointUpdateDto dto)
    {
        var result = await _pointService.UpdateAsync(dto, ModelState);

        if (!result)
        {
            return View(dto);

        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _pointService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }
}
