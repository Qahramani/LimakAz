using LimakAz.Application.Interfaces.Services;
using LimakAz.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;

public class ContentController : Controller
{
    private readonly IContentService _contentService;
    private readonly ICookieService _cookieService;

    public ContentController(IContentService contentService, ICookieService cookieService)
    {
        _contentService = contentService;
        _cookieService = cookieService;
    }

    public async Task<IActionResult> Terms()
    {
        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        var dtos = _contentService.GetByPageType(PageType.Terms, language);

        return View(dtos);
    }

    public async Task<IActionResult> Privacy()
    {
        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        var dtos = _contentService.GetByPageType(PageType.Privacy, language);

        return View(dtos);
    }

    public async Task<IActionResult> Questions()
    {
        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        var dtos = _contentService.GetByPageType(PageType.FAQ, language);

        return View(dtos);
    }
}
