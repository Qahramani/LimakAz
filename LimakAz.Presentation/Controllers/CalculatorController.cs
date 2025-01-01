using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;

public class CalculatorController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
