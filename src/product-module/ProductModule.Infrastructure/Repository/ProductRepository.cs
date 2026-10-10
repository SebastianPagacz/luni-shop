using Microsoft.EntityFrameworkCore;
using ProductModule.Domain.Abstractions;
using ProductModule.Domain.Models;
using ProductModule.Infrastructure.Context;

namespace ProductModule.Infrastructure.Repository;

public class ProductRepository(AppDbContext context) : IRepository<Product>
{
    public void AddItem(Product item)
    {
        context.Products.Add(item);
    }

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Products.ToListAsync(cancellationToken);
    }

    public async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Products.Where(product => product.Id == id).FirstOrDefaultAsync(cancellationToken);
    }
}