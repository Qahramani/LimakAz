using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
public class CertificateController : Controller
{
    private readonly ICertificateService _certificateService;

    public CertificateController(ICertificateService certificateService)
    {
        _certificateService = certificateService;
    }

    public async Task<IActionResult> Index(int page = 1)
    {
        var items = await _certificateService.GetPages(page :  page, limit : 3);

        return View(items);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CertificateCreateDto dto)
    {
        var result =await  _certificateService.CreateAsync(dto, ModelState);

        if (!result)
        {
            return View(dto);
        }
        return RedirectToAction(nameof(Index)); 
    }

}
