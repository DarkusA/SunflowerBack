using Domain.Interfaces;

namespace Infrastructure.Repositories;

//Guardado en memoria para la demo
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    public readonly List<T> _items = new();

    public List<T> GetAll()
    {
        return _items;
    }
    public void Delete(T item)
    {
        _items.Remove(item);
    }
}