using Microsoft.AspNetCore.Mvc;

namespace IFDb.Host.Controllers;

public class Home : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}