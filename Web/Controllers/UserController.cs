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
        return Ok(_userService.GetUser(id));
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
        _userService.UpdateUser(id, user);

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteUser(int id)
    {
        _userService.DeleteUser(id);

        return Ok();
    }
}