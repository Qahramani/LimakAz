using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;
public class NotificationController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
