using LuniShop.Shared.Abstractions.Results;

namespace LuniShop.Module.Products.Core.Domain.Models;

public class Category
{
    public Guid Id { get; init; }
    public string Name { get; private set; } = string.Empty;

    private Category(string name)
    {
        Name = name;
    }

    public static Result<Category> CreateCategory(string name)
    {
        if(string.IsNullOrWhiteSpace(name) || name.Length > 256)
            return ResultFactory.Failure<Category>("Name can't be empty or exceed 256 characters.");

        return ResultFactory.Success(new Category(name));
    }
    public Result<Category> ChangeName(string newName)
    {
        if(string.IsNullOrWhiteSpace(newName) || newName.Length > 256)
            return ResultFactory.Failure<Category>("Name can't be empty or exceed 256 characters.");

        Name = newName;
        return ResultFactory.Success(this);
    }
}
