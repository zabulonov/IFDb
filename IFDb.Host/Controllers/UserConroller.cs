using Core.Models;
using IFDb.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace IFDb.Host.Controllers;

[Route("API/User")]
[ApiController]
public class UserConroller
{
    private readonly UserService _userService;
    
    public UserConroller(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task AddUser([FromBody] UserModel model)
    {
        await _userService.AddUser(model);
    }
    
    [HttpGet("info/{userId}")]
    public async Task<object> InfoUser(long userId)
    {
        var userInfo = await _userService.GetUserInfo(userId);
        return userInfo;
    }
    
    [HttpGet("delete/{userId}")]
    public async Task DeleteUser(long userId)
    {
        await _userService.DeleteUser(userId);
    }
    
    [HttpPost("edit/{id}")]
    public async Task EditUser([FromBody] UserModel model, long id)
    {
        await _userService.EditUser(model, id);
    }
}