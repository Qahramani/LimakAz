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

    public IActionResult Index()
    {
        var dtos = _shopService.GetAll();

        return View(dtos);
    }

    public async IActionResult Create()
    {
        var dto = 
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ShopCreateDto dto)
    {
        var result = await _shopService.CreateAsync(dto, ModelState);

        if (!result)
            return View(dto);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var country = await _shopService.GetUpdatedDtoAsync(id);

        return View(country);
    }

    [HttpPost]
    public async Task<IActionResult> Update(ShopUpdateDto dto)
    {
        var result = await _shopService.UpdateAsync(dto, ModelState);
        if (!result)
            return View(dto);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _shopService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }

}