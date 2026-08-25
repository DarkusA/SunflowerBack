using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public User? Get(int id)
    {
        return _items.FirstOrDefault(u => u.Id == id);
    }

    public void Add(User user)
    {
        user.Id = _items.Count + 1;
        _items.Add(user);
    }

    public void Update(User user)
    {
        User? userToUpdate = _items.FirstOrDefault(u => u.Id == user.Id);

        if (userToUpdate != null)
        {
            userToUpdate.Username = user.Username;
            userToUpdate.Password = user.Password;
            userToUpdate.Email = user.Email;
            userToUpdate.Role = user.Role;
        }
    }
}