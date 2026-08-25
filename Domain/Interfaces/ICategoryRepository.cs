using Domain.Entities;

namespace Domain.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Category? Get(int id);
    void Add(Category category);
    void Update(Category category);
}