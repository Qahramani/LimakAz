using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;

public class NewsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Details()
    {
        return View();
    }
}
