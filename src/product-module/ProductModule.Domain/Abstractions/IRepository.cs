namespace ProductModule.Domain.Abstractions;

public interface IRepository<T>
{
    void AddItem(T item);
    Task<T> GetById(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default);
}