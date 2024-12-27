using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace LimakAz.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
public class CountryController : Controller
{
    private readonly ICountryService _countryService;

    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    public IActionResult Index()
    {
        var countries = _countryService.GetAll();

        return View(countries);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CountryCreateDto dto)
    {
        var result = await _countryService.CreateAsync(dto, ModelState);

        if (!result)
            return View(dto);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var country = await _countryService.GetUpdatedDtoAsync(id);

        return View(country);
    }

    [HttpPost]
    public async Task<IActionResult> Update(CountryUpdateDto dto)
    {
        var result = await _countryService.UpdateAsync(dto, ModelState);
        if (!result)
            return View(dto);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _countryService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }
}
