using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    private int _nextId = 1;
    public Category? Get(int id)
    {
        return _items.FirstOrDefault(c => c.Id == id);
    }

    public void Add(Category category)
    {
        category.Id = _nextId++;
        _items.Add(category);
    }

    public void Update(Category category)
    {
        Category? categoryToUpdate = _items.FirstOrDefault(c => c.Id == category.Id);

        if (categoryToUpdate != null)
        {
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Description = category.Description;
        }
    }
}
