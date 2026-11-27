using LuniShop.Module.Products.Core.Domain.Models;
using LuniShop.Module.Products.Core.Infrastructure.Context;
using LuniShop.Shared.Abstractions.Persistence;
using LuniShop.Shared.Abstractions.Results;
using Microsoft.EntityFrameworkCore;

namespace LuniShop.Module.Products.Core.Infrastructure.Implementations;

public class CategoryRepository : IRepository<Category>
{
    private AppDbContext _context;
    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }
    public void Add(Category item)
    {
        _context.Categories.Add(item);
    }

    public async Task<PagedResult<Category>> GetAsync(int pageSize, int currentPage, CancellationToken ct = default)
    {
        var categories = await _context
            .Categories
            .OrderBy(x => x.Name)
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);

        var totalCategoriesCount = await _context
            .Categories
            .CountAsync(ct);

        return PagedResultFactory.Create(categories, pageSize, currentPage, totalCategoriesCount);
    }

    public async Task<Result<Category>> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var category = await _context
            .Categories
            .FirstOrDefaultAsync(x => x.Id == id, ct);

        if (category is not null)
            return ResultFactory.Success(category);

        return ResultFactory.Failure<Category>($"Category with id {id} was not found");
    }
}
