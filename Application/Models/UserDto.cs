using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Application.Models;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
}