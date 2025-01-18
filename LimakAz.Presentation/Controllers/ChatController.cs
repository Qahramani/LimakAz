using LimakAz.Application.Interfaces.Repositories;
using LimakAz.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace LimakAz.Presentation.Controllers;

public class ChatController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}
