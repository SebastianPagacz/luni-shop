namespace ProductModule.Domain.Abstractions;

public interface IRepository<T>
{
    void AddItem(T item);
    T GetById(Guid id);
    IEnumerable<T> GetAll();
}