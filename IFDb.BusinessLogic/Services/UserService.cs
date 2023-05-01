using Core;
using Core.Models;
using IFDb.Infrastructure;

namespace IFDb.BusinessLogic.Services;

public class UserService
{
    private readonly FilmDbContextFactory _factory;

    public UserService(FilmDbContextFactory factory)
    {
        _factory = factory;
    }
    
    public async Task AddUser(UserModel model)
    {
        var context = _factory.GetContext();
        var user = new User(model);
        context.AddUser(user);
        await context.SaveChangesAsync();
    }
}