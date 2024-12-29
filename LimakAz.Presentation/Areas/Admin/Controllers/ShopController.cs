using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
public class ShopController : Controller
{

    private readonly IShopService _shopService;

    public ShopController(IShopService shopService)
    {
        _shopService = shopService;
    }

    public async Task<IActionResult> Index()
    {
        var dtos = await _shopService.GetPagesAsync();

        return View(dtos);
    }

    public IActionResult Create()
    {
        var dto = _shopService.GetCreateDto(new ShopCreateDto());

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ShopCreateDto dto)
    {
        var result = await _shopService.CreateAsync(dto, ModelState);

        if (!result)
        {
            dto =  _shopService.GetCreateDto(dto);
            return View(dto);
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var dto = await _shopService.GetUpdatedDtoAsync(id);

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Update(ShopUpdateDto dto)
    {
        var result = await _shopService.UpdateAsync(dto, ModelState);
        if (!result)
        {
            dto = await _shopService.GetUpdatedDtoAsync(dto.Id);
            return View(dto);

        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _shopService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }

}