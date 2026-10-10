using Microsoft.EntityFrameworkCore;
using ProductModule.Domain.Abstractions;
using ProductModule.Domain.Models;
using ProductModule.Infrastructure.Context;

namespace ProductModule.Infrastructure.Repository;

public class CategoryRepository(AppDbContext context) : IRepository<Category>
{
    public void AddItem(Category item)
    {
        context.Categories.Add(item);
    }

    public async Task<IEnumerable<Category>> GetAll(CancellationToken cancellationToken = default)
    {
        return await context.Categories.ToListAsync(cancellationToken);
    }

    public async Task<Category> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Categories.Where(category => category.Id == id).FirstOrDefaultAsync(cancellationToken);
    }
}