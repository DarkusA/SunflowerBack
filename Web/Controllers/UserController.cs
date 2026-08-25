using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;  

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(_userService.GetUsers());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetUserById(int id)
    {
        UserDto? user = _userService.GetUser(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser(CreateUserDto user)
    {
        _userService.AddUser(user);
        return Ok();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateUser(int id, UpdateUserDto user)
    {
        bool isUpdated = _userService.UpdateUser(id, user);

        if (!isUpdated)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteUser(int id)
    {
        bool isDeleted = _userService.DeleteUser(id);

        if (!isDeleted)
        {
            return NotFound();
        }

        return Ok();
    }
}