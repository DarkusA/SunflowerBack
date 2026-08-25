using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    User? Get(int id);
    void Add(User user);
    void Update(User user);
}