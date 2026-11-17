using LuniShop.Shared.Abstractions.Results;

namespace LuniShop.Shared.Abstractions.Persistence;

public interface IRepository<T>
{
    void Add();
    Task<Result<T>> GetByIdAsync(Guid id);
    Task<PagedResult<IList<T>>> GetAsync(int pageSize, int currentPage);
}
