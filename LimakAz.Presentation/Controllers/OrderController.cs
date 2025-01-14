using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;

public class OrderController : Controller
{
    public IActionResult Index(string? orderLink)
    {
        return View();
    }
}
