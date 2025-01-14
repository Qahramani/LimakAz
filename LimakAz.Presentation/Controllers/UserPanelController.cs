using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;

public class UserPanelController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
