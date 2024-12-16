using LimakAz.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LimakAz.Presentation.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

    }
}
