using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;

public class ShopController : Controller
{
    
    public IActionResult Index()
    {
        return View();
    }
}
