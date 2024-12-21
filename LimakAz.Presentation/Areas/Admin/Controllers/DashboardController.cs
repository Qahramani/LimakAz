using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
