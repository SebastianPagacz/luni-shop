using LuniShop.Module.Products.Core.Domain.Models;
using LuniShop.Module.Products.Core.Infrastructure.Context;
using LuniShop.Shared.Abstractions.Persistence;
using LuniShop.Shared.Abstractions.Results;
using Microsoft.EntityFrameworkCore;

namespace LuniShop.Module.Products.Core.Infrastructure.Implementations;

public class ProductRepository : IRepository<Product>
{
    private AppDbContext _context;
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    public void Add(Product item)
    {
        _context.Add(item); // Do I have to do it that way? I mean do I have to add "item" argument to the method?
    }

    public async Task<PagedResult<Product>> GetAsync(int pageSize, int currentPage) // Right now this method is fully synchronus, I probably need to move pagination from the paged result to respective methods that are using paged result to make them trully async
    {
        var products = _context
            .Products
            .AsQueryable();

        var totalProductsCount = _context
            .Products
            .Count();

        return PagedResultFactory.Create(products, pageSize, currentPage, totalProductsCount);
    }

    public async Task<Result<Product>> GetByIdAsync(Guid id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

        if (product is not null)
            return ResultFactory.Success(product);

        return ResultFactory.Failure<Product>($"Product with Id {id} was not found");
    }
}
