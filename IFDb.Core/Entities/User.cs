using Core.Models;

namespace Core;

public class User
{
    public long Id { get; private set; }
    public string Login { get; private set; }
    public string Password { get; private set; }
    public bool isAdmin { get; private set; }

    public User()
    {
        
    }

    public User(UserModel model)
    {
        Login = model.Login;
        Password = model.Password;
        isAdmin = false;
    }
}