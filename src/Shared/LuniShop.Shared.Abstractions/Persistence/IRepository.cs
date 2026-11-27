using LuniShop.Shared.Abstractions.Results;

namespace LuniShop.Shared.Abstractions.Persistence;

public interface IRepository<T>
{
    void Add(T item);
    Task<Result<T>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<T>> GetAsync(int pageSize, int currentPage, CancellationToken ct = default);
}
