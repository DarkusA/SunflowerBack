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

    public CategoryDto? GetCategory(int id)
    {
        Category? category = _categoryRepository.Get(id);

        if (category == null)
        {
            return null;
        }

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

    public bool UpdateCategory(int id, CreateAndUpdateCategoryDto category)
    {
        Category? categoryToUpdate = _categoryRepository.Get(id);

        if (categoryToUpdate == null)
        {
            return false;
        }

        categoryToUpdate.Name = category.Name;
        categoryToUpdate.Description = category.Description;

        _categoryRepository.Update(categoryToUpdate);
        return true;
    }

    public bool DeleteCategory(int id)
    {
        Category? categoryToDelete = _categoryRepository.Get(id);

        if (categoryToDelete == null)
        {
            return false;
        }
        
        _categoryRepository.Delete(categoryToDelete);
        return true;
    }
}