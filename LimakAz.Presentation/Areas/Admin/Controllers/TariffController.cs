﻿using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin,Moderator")]
public class TariffController : Controller
{
    private readonly ITariffService _tariffService;
    public TariffController(ITariffService tariffService)
    {
        _tariffService = tariffService;
    }

    public async Task<IActionResult> Index(int countryId)
    {
        ViewData["CountryId"] = countryId;

        var tariffs = await _tariffService.GetTariffsByCountry(countryId);

        return View(tariffs);
    }
    public IActionResult Create(int countryId)
    {
        ViewData["CountryId"] = countryId;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(TariffCreateDto dto)
    {
        ViewData["CountryId"] = dto.CountryId;

        var result = await _tariffService.CreateAsync(dto, ModelState);


        if(!result)
            return View(dto);

        return RedirectToAction(nameof(Index), new { countryId = dto.CountryId});
    }

    public async Task<IActionResult> Update(int id, int countryId)
    {
        var dto = await _tariffService.GetUpdatedDtoAsync(id);

        ViewData["CountryId"] = countryId;
        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Update(TariffUpdateDto dto)
    {
        ViewData["CountryId"] = dto.CountryId;

        var result = await _tariffService.UpdateAsync(dto, ModelState);


        if (!result)
            return View(dto);

        return RedirectToAction(nameof(Index), new { countryId = dto.CountryId });
    }
    public async Task<IActionResult> Delete(int id)
    {
        await _tariffService.DeleteAsync(id); 
        
        
        return RedirectToAction("Index", "Country");

    }
}
