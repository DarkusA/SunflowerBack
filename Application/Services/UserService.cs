using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class UserService //No tiene interfaz, consultar luego
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<UserDto> GetUsers()
    {
        List<User> users = _userRepository.GetAll();

        return users
            .Select(user => new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            })
            .ToList();
    }

    public UserDto? GetUser(int id)
    {
        User? userById = _userRepository.Get(id);

        if (userById == null)
        {
            return null;
        }

        return new UserDto
        {
            Id = userById.Id,
            Username = userById.Username,
            Email = userById.Email,
            Role = userById.Role
        };
    }

    public void AddUser(CreateUserDto user)
    {
        _userRepository.Add(
            new User
            {
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                Role = Role.User
            }
        );
    }

    public bool UpdateUser(int id, UpdateUserDto user)
    {
        User? userToUpdate = _userRepository.Get(id);
    
        if (userToUpdate == null)
        {
            return false;
        }
    
        userToUpdate.Username = user.Username;
        userToUpdate.Email = user.Email;
        userToUpdate.Password = user.Password;
        userToUpdate.Role = user.Role; //Revisar esto

        _userRepository.Update(userToUpdate);

        return true;
    }

    public bool DeleteUser(int id)
    {
        User? userToDelete = _userRepository.Get(id);
    
        if (userToDelete == null)
        {
            return false;
        }

        _userRepository.Delete(userToDelete);
        return true;
    }
}