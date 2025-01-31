using LimakAz.Application.DTOs;
using LimakAz.Application.Interfaces.Services;
using LimakAz.Application.Interfaces.Services.External;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Globalization;

namespace LimakAz.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
public class OrderController : Controller
{
    private readonly IPackageService _packageService;
    private readonly ICookieService _cookieService;
    private readonly IEmailService _emailService;
    public OrderController(IPackageService packageService, ICookieService cookieService, IEmailService emailService)
    {
        _packageService = packageService;
        _cookieService = cookieService;
        _emailService = emailService;
    }

    public async Task<IActionResult> Index(int statusId = 0)
    {
        var packages = await _packageService.GetFilteredPackagesAsync(statusId);

        return View(packages);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var language = await _cookieService.GetSelectedLanguageTypeAsync();

        var result = await _packageService.GetAsync(id, language);

        return View(result);
    }
    [HttpPost]
    public async Task<IActionResult> SendNotificationEmail(int packageId)
    {
        await _packageService.SendNotificationEmail(packageId);
        TempData["Success"] = "Email sent successfully!";
        return RedirectToAction("Detail", new { id = packageId });
    }
    [HttpPost]
    public async Task<IActionResult> UpdateWeight(int id, string newWeight)
    {
        decimal result;

        if (decimal.TryParse(newWeight, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            await _packageService.UpdateWeigth(id, result);

        return RedirectToAction(nameof(Detail), new { id = id });
    }
    public async Task<IActionResult> PrevStatus(int id)
    {
        await _packageService.PrevOrderStatusAsync(id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> NextStatus(int id)
    {
        await _packageService.NextOrderStatusAsync(id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> CancelOrder(int id)
    {
        await _packageService.CancelPackageAsync(id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> RepairOrder(int id)
    {
        await _packageService.RepairPackageAsync(id);

        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Delete(int id)
    {
        await _packageService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> FinishOrder(int id)
    {
        await _packageService.FinishOrderAsync(id);

        return RedirectToAction(nameof(Detail), new { id = id });
    }

}
