using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Application.Models;

public class UpdateUserDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
}