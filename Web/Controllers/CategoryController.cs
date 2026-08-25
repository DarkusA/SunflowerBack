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
        return Ok(_categoryService.GetCategory(id));
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
        _categoryService.UpdateCategory(id, category);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteCategory(int id)
    {
        _categoryService.DeleteCategory(id);
        return Ok();
    }
}