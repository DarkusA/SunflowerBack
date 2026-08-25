using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly CategoryService _categoryService;

    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult GetCategories()
    {
        return Ok(_categoryService.GetCategories());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetCategoryById(int id)
    {
        CategoryDto? category = _categoryService.GetCategory(id);

        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpPost]
    public IActionResult CreateCategory(CreateAndUpdateCategoryDto category)
    {
        _categoryService.AddCategory(category);
        return Ok();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateCategory(int id, CreateAndUpdateCategoryDto category)
    {
        bool isUpdated = _categoryService.UpdateCategory(id, category);

        if (!isUpdated)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteCategory(int id)
    {
        bool isDeleted = _categoryService.DeleteCategory(id);

        if (!isDeleted)
        {
            return NotFound();
        }

        return Ok();
    }
}