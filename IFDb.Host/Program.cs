using Core;
using IFDb.BusinessLogic.Services;
using IFDb.Host.Controllers;
using IFDb.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton(isp => new FilmDbContextFactory(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<FilmInfo>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapDefaultControllerRoute();

var factory = app.Services.GetRequiredService<FilmDbContextFactory>();
var context = factory.GetContext();
var database = context.Database;
//database.Migrate();

app.Run();