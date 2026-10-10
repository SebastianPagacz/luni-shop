namespace ProductModule.Domain.Abstractions;

public interface IRepository<T>
{
    void AddItem(T item);
    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
}