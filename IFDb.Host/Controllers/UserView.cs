using Core;
using Core.Models;
using IFDb.BusinessLogic.Services;
using IFDb.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IFDb.Host.Controllers;

public class UserView : Controller
{

    private readonly FilmDbContextFactory _factory;
    private readonly UserService _userService;


    public UserView(FilmDbContextFactory factory, UserService userService)
    {
        _factory = factory;
        _userService = userService;
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
    
    public async Task<IActionResult> Edit(int? id)
    {
        var context = _factory.GetContext();
        if (id == null) return NotFound();
        var user = context.Users.FirstOrDefaultAsync(p=>p.Id==id);
        if (user != null) return View(user.Result);
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> Edit(User user)
    {
        var context = _factory.GetContext();
        context.Users.Update(user);
        context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> Delete(long id)
    {
        _userService.DeleteUser(id);
        return RedirectToAction("Index");
    }
}