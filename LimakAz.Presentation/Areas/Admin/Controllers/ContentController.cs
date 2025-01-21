using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace LimakAz.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin,Moderator")]
public class ContentController : Controller
{
    private readonly IContentService _contentService;

    public ContentController(IContentService contentService)
    {
        _contentService = contentService;
    }

    public async Task<IActionResult> Index()
    {
        var contents = await _contentService.GetPagesAsync(page:5);

        return View(contents);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ContentCreateDto dto)
    {
        var result = await _contentService.CreateAsync(dto, ModelState);

        if (!result)
        {
            return View(dto);
        }
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Update(int Id)
    {
        var dto = await _contentService.GetUpdatedDtoAsync(Id);

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Update(ContentUpdateDto dto)
    {
        var result = await _contentService.UpdateAsync(dto, ModelState);

        if (!result)
        {
            return View(dto);
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _contentService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }
}

