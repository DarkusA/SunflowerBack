using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class CategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public List<CategoryDto> GetCategories()
    {
        List<Category> categories = _categoryRepository.GetAll();

        return categories
            .Select(category => new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            })
            .ToList();
    }

    public CategoryDto GetCategory(int id)
    {
        Category? category = _categoryRepository.Get(id);

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
    }

    public void AddCategory(CreateAndUpdateCategoryDto category)
    {
        _categoryRepository.Add(
            new Category
            {
                Name = category.Name,
                Description = category.Description
            }
        );
    }

    public void UpdateCategory(int id, CreateAndUpdateCategoryDto category)
    {
        Category? categoryToUpdate = _categoryRepository.Get(id);

        categoryToUpdate.Name = category.Name;
        categoryToUpdate.Description = category.Description;

        _categoryRepository.Update(categoryToUpdate);
    }

    public void DeleteCategory(int id)
    {
        Category? categoryToDelete = _categoryRepository.Get(id);

        _categoryRepository.Delete(categoryToDelete);
    }
}