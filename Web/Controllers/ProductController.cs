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
        return Ok(_productService.GetProduct(id));
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
        _productService.UpdateProduct(id, product);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteProduct(int id)
    {
        _productService.DeleteProduct(id);
        return Ok();
    }
}