using CMS.Domain.DTOs.User;
using CMS.Domain.Services.User;
using CMS.Shared.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UsersController : CustomBaseController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public  async Task<IActionResult> GetUserById(int userId)
    {
        return ActionResultInstance(await _userService.GetUserByIdAsync(userId));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        return ActionResultInstance(await _userService.GetAllUsersAsync());
    }

    [HttpGet]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        return ActionResultInstance(await _userService.GetUserByEmailAsync(email));
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(UserDto  userDto)
    {
        return ActionResultInstance(await _userService.AddUserAsync(userDto));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(int userId,UserDto userDto)
    {
        return ActionResultInstance(await _userService.UpdateUserAsync(userId, userDto));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        return ActionResultInstance(await _userService.DeleteUserAsync(userId));
    }

    [HttpGet]
    public async Task<IActionResult> GetUserContentAsync(int userId)
    {
        return ActionResultInstance(await _userService.GetUserContentAsync(userId));
    }
}
