using ProductModule.Domain.Models;

namespace ProductModule.Application.Services;

public interface ICategoryQueryService
{
    Task<Category> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<Category>> GetCategoriesAsync(Guid id, CancellationToken cancellationToken = default);
}