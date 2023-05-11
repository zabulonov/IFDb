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
        await context.AddUser(user);
        await context.SaveChangesAsync();
    }
    
    public async Task DeleteUser(long id)
    {
        var context = _factory.GetContext();

        var deleteUser = await context.FindUser(id);
        context.Remove(deleteUser);
        await context.SaveChangesAsync();
    }
    
    public async Task<object> GetUserInfo(long Id)
    {
        var context = _factory.GetContext();
        var user = await context.FindUser(Id);
        return new
        {
            Login = user.Login,
            Password = user.Password,
            isAdmin = user.isAdmin
        };
    }
    
    public async Task EditUser(UserModel model, long id)
    {
        var context = _factory.GetContext();
        
        var user = await context.FindUser(id);
        user.UpdateUser(model);
        context.Update(user);
        await context.SaveChangesAsync();
    }
}