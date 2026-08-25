using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(_productService.GetProducts());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetProductById(int id)
    {
        ProductDto? product = _productService.GetProduct(id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public IActionResult CreateProduct(CreateAndUpdateProductDto product)
    {
        _productService.AddProduct(product);
        return Ok();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateProduct(int id, CreateAndUpdateProductDto product)
    {
        bool isUpdated = _productService.UpdateProduct(id, product);

        if (!isUpdated)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteProduct(int id)
    {
        bool isDeleted = _productService.DeleteProduct(id);

        if (!isDeleted)
        {
            return NotFound();
        }

        return Ok();
    }
}