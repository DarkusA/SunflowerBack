namespace Domain.Interfaces;
// Saque el get y Update ya que necesitan Id, y no puedo buscar por Id en el generico teniendo la lista guardada en memoria.
public interface IBaseRepository<T> where T : class
{
    List<T> GetAll();
    void Delete(T item);
}