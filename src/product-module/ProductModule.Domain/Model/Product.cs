using ProductModule.Domain.ValueObjects;

namespace ProductModule.Domain.Model;

public class Product
{
    private Product() { }
    private Product(string name, string? description, Money price, int stock)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public Money Price { get; private set; }
    public int Stock { get; private set; }
    public bool IsActive { get; private set; } = false;
    public bool IsDeleted { get; private set; } = false;
    public DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; private set; }

    public static Product Create(string name, string? description, Money price, int stock)
    {
        if (!ValidateName(name))
            throw new Exception();
        
        if (!ValidatePrice(price))
            throw new Exception();

        if (!ValidateStock(stock))
            throw new Exception();

        return new Product(name, description, price, stock);
    } 

    private static bool ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 256)
            return false;

        return true;
    }
    private static bool ValidatePrice(Money price)
    {
        if (price.Value < 0 || price.Currency.Length != 3)
            return false;

        return true;
    }
    private static bool ValidateStock(int stock)
    {
        if (stock < 0)
            return false;

        return true;
    }
    private void Update()
    {
        UpdatedAt = DateTimeOffset.UtcNow;
    }
}