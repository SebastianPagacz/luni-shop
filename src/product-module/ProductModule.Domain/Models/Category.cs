using ProductModule.Domain.Exceptions;

namespace ProductModule.Domain.Models;

public class Category
{
    private Category() { }
    private Category(string name)
    {
        Name = name;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public bool IsActive { get; private set; } = false;
    public bool IsDeleted { get; private set; } = false;
    public DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; private set; }

    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();
    private List<Product> _products = new();
    
    public Category Create(string name)
    {
        ValidateName(name);

        return new Category(name);
    }
    public void SetName(string newName)
    {
        ValidateName(newName);
        Name = newName;
        Update();
    }

    private static bool ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 256)
            throw new DomainException("Name can't be empty or exceed 256 characters.");

        return true;
    }
    private void Update()
    {
        UpdatedAt = DateTimeOffset.UtcNow;
    }
}