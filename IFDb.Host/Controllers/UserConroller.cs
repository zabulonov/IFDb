using Core.Models;
using IFDb.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace IFDb.Host.Controllers;

[Route("User")]
[ApiController]
public class UserConroller
{
    private readonly UserService _userService;
    
    public UserConroller(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("add")]
    public async Task AddPostUser([FromBody] UserModel model)
    {
        await _userService.AddUser(model);
    }
}