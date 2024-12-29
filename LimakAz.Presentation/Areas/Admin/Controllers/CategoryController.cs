using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public IActionResult Index()
    {
        var dtos =  _categoryService.GetAll();

        return View(dtos);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryCreateDto dto)
    {
        var result = await _categoryService.CreateAsync(dto, ModelState);

        if (!result)
            return View(dto);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var country = await _categoryService.GetUpdatedDtoAsync(id);

        return View(country);
    }

    [HttpPost]
    public async Task<IActionResult> Update(CategoryUpdateDto dto)
    {
        var result = await _categoryService.UpdateAsync(dto, ModelState);
        if (!result)
            return View(dto);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _categoryService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }
}
