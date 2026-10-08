using ProductModule.Domain.Exceptions;
using ProductModule.Domain.ValueObjects;

namespace ProductModule.Domain.Models;

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

    public IReadOnlyCollection<Category> Categories => _categories;
    private List<Category> _categories = new();

    public static Product Create(string name, string? description, Money price, int stock)
    {
        ValidateName(name);
        ValidatePrice(price);
        ValidateStock(stock);

        return new Product(name, description, price, stock);
    } 

    public void SetName(string name)
    {
        ValidateName(name);
        Name = name;
        Update();
    }
    public void SetPrice(Money price)
    {
        ValidatePrice(price);
        Price = price;
        Update();
    }
    public void SetStock(int stock)
    {
        ValidateStock(stock);
        Stock = stock;
        Update();
    }
    public void SubtractStock(int toSubtract)
    {
        if (toSubtract <= 0 || toSubtract > Stock)
            throw new DomainException("Can't subtract negative value and to subtract can't exceed the target value."); // debetable DomainException

        Stock -= toSubtract;
        Update();
    }
    public void AddStock(int toAdd)
    {
        if (toAdd <= 0)
            throw new DomainException("Can't add negative value.");

        Stock += toAdd;
        Update();
    }

    private static bool ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 256)
            throw new DomainException("Name can't be empty or exceed 256 characters.");

        return true;
    }
    private static bool ValidatePrice(Money price)
    {
        if (price.Value < 0 || price.Currency.Length != 3)
            throw new DomainException("Price can't be negative, currency code has to be 3 characters long.");

        return true;
    }
    private static bool ValidateStock(int stock)
    {
        if (stock < 0)
            throw new DomainException("Stock can't be negative.");
        
        return true;
    }
    private void Update()
    {
        UpdatedAt = DateTimeOffset.UtcNow;
    }
}