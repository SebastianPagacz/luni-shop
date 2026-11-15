using LuniShop.Module.Products.Core.Domain.Primitives;
using LuniShop.Shared.Abstractions.Results;

namespace LuniShop.Module.Products.Core.Domain.Models;

public class Product
{
    public Guid Id { get; init; }
    public string Name { get; private set; } = string.Empty;
    public Money Price { get; private set; }
    public int Stock { get; private set; }
    // Relations
    public IReadOnlyCollection<Category> Categories => _categories.AsReadOnly();
    private readonly IList<Category> _categories = new List<Category>();

    private Product(string name, Money price, int stock)
    {
        Name = name;
        Price = price;
        Stock = stock;
    }

    public static Result<Product> CreateProduct(string name, Money price, int stock)
    {
        if(string.IsNullOrWhiteSpace(name) || name.Length > 256)
            return Result.Failure<Product>("Name can't be null, white space or exceed 256 characters.");

        if(stock < 0)
            return Result.Failure<Product>("Stock can't be below 0");

        return Result.Success(new Product(name, price, stock));
    }
    public Result<Product> SetName(string newName)
    {
        if(string.IsNullOrWhiteSpace(newName) || newName.Length > 256)
            return Result.Failure<Product>("Name can't be null, white space or exceed 256 characters.");

        Name = newName;
        return Result.Success(this);
    }
    public Result<Product> SetPrice(Money newPrice)
    {
        Price = newPrice;
        return Result.Success(this);
    }
    public Result<Product> SetStock(int newStock)
    {
        if(newStock < 0)
            return Result.Failure<Product>("Stock can't be below 0");

        Stock = newStock;
        return Result.Success(this);
    }
}
