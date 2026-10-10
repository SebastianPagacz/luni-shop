using ProductModule.Domain.Models;

namespace ProductModule.Application.Services;

public interface IProductQueryService
{
    Task<Product> GetProductByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<Product>> GetProductsAsync(Guid id, CancellationToken cancellationToken = default);
}