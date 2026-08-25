using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductRepository : IBaseRepository<Product>
{
    Product? Get(int id);
    void Add(Product product);
    void Update(Product product);
}