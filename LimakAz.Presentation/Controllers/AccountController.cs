using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;

public class AccountController : Controller
{
    public IActionResult Register()
    {
        return View();
    }
}
