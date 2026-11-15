using LuniShop.Shared.Abstractions.Results;

namespace LuniShop.Module.Products.Domain.Models;

public class Product
{
    public Guid Id { get; init; }
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; } // Think about creating primitive type for money
    public int Stock { get; private set; }

    private Product() {}
    private Product(string name, decimal price, int stock)
    {
        Name = name;
        Price = price;
        Stock = stock;
    }

    public static Result<Product> CreateProduct(string name, decimal price, int stock)
    {
        if(string.IsNullOrWhiteSpace(name) || name.Length > 256)
            return Result.Failure<Product>("Name can't be null, white space or exceed 256 characters.");

        if(price <= 0)
            return Result.Failure<Product>("Price can't be 0 or below.");

        if(stock < 0)
            return Result.Failure<Product>("Stock can't be below 0");
        
        return Result.Success(new Product(name, price, stock));
    }
}
