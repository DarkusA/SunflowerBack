using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    private int _nextId = 1;
    public Product? Get(int id)
    {
        return _items.FirstOrDefault(p => p.Id == id);
    }

    public void Add(Product product)
    {
        product.Id = _nextId++;
        _items.Add(product);
    }

    public void Update(Product product)
    {
        Product? productToUpdate = _items.FirstOrDefault(p => p.Id == product.Id);

        if (productToUpdate != null)
        {
            productToUpdate.Name = product.Name;
            productToUpdate.Description = product.Description;
            productToUpdate.Price = product.Price;
            productToUpdate.Stock = product.Stock;
            productToUpdate.CategoryId = product.CategoryId;
        }
    }
}