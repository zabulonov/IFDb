using Core;
using Core.Models;
using IFDb.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IFDb.Host.Controllers;

public class UserView : Controller
{

    private readonly FilmDbContextFactory _factory;


    public UserView(FilmDbContextFactory factory)
    {
        _factory = factory;
    }
    
    public async Task<IActionResult> Index()
    {
        var _context = _factory.GetContext();
        return View( _context.Set<User>());
    }
    
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(UserModel userModel)
    {
        var context = _factory.GetContext();
        var user = new User(userModel);
        context.AddUser(user);
        context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}