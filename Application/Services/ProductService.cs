using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class ProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<ProductDto> GetProducts()
    {
        List<Product> products = _productRepository.GetAll();

        return products
            .Select(product => new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId
            })
            .ToList();
    }

    public ProductDto? GetProduct(int id)
    {
        Product? productById = _productRepository.Get(id);

        if (productById == null)
        {
            return null;
        }

        return new ProductDto
        {
            Id = productById.Id,
            Name = productById.Name,
            Description = productById.Description,
            Price = productById.Price,
            Stock = productById.Stock,
            CategoryId = productById.CategoryId
        };
    }

    public void AddProduct(CreateAndUpdateProductDto product)
    {
        _productRepository.Add(
            new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId
            }
        );
    }

    public bool UpdateProduct(int id, CreateAndUpdateProductDto product)
    {
        Product? productToUpdate = _productRepository.Get(id);

        if (productToUpdate == null)
        {
            return false;
        }

        productToUpdate.Name = product.Name;
        productToUpdate.Description = product.Description;
        productToUpdate.Price = product.Price;
        productToUpdate.Stock = product.Stock;
        productToUpdate.CategoryId = product.CategoryId;

        _productRepository.Update(productToUpdate);
        
        return true;
    }

    public bool DeleteProduct(int id)
    {
        Product? productToDelete = _productRepository.Get(id);

        if (productToDelete == null)
        {
            return false;
        }

        _productRepository.Delete(productToDelete);
        return true;
    }
}