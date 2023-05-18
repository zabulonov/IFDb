using Microsoft.AspNetCore.Mvc;

namespace IFDb.Host.Controllers;

public class FilmInfoController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}