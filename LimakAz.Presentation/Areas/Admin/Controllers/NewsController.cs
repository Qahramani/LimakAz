using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin,Moderator")]
public class NewsController : Controller
{
    private readonly INewsService _newsService;

    public NewsController(INewsService newsService)
    {
        _newsService = newsService;
    }

    public async Task<IActionResult> Index(int page = 1)
    {
        var news = await _newsService.GetPagesAsync(page : page, limit : 3);

        return View(news);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(NewsCreateDto dto)
    {
        var result = await _newsService.CreateAsync(dto, ModelState);

        if(!result)
            return View(dto);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var dto = await _newsService.GetUpdatedDtoAsync(id);

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Update(NewsUpdateDto dto)
    {
        var result = await _newsService.UpdateAsync(dto, ModelState);

        if(!result)
            return View(dto);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _newsService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }

}
