using LuniShop.Module.Products.Core.Domain.Models;
using LuniShop.Module.Products.Core.Domain.Primitives;

namespace LuniShop.Products.UnitTests.Domain.Models;

public class ProductTests
{
    private const string _validName = "TestProduct";
    private const int _validStock = 10;
    private const string _nameErrorMessage = "Name can't be null, white space or exceed 256 characters.";

    [Fact]
    public void CreateProduct_ShouldReturnSuccessfulResult_WhenProvidingValidData()
    {
        // Arrange
        var validMoney = Money.CreatePln(100).Value!; // This is definetly not null

        // Act
        var product = Product.CreateProduct(_validName, validMoney, _validStock);

        // Assert
        Assert.True(product.IsSuccess);
        Assert.Null(product.ErrorMessage);
        Assert.Equal(_validName, product.Value.Name);
        Assert.Equal(_validStock, product.Value.Stock);
    }

    public static TheoryData<string?> CreateProduct_ShouldReturnSuccessfulResult_WhenProvidingIn_validName_Data => new()
    {
        "",
        "  ",
        new('a', 257),
        null, // ToDo: Review this test case, does null should be a case?
    };

    [Theory]
    [MemberData(nameof(CreateProduct_ShouldReturnSuccessfulResult_WhenProvidingIn_validName_Data))]
    public void CreateProduct_ShouldReturnSuccessfulResult_WhenProvidingIn_validName(string? name)
    {
        // Arrange
        var validMoney = Money.CreatePln(100).Value!;

        // Act
        var product = Product.CreateProduct(name!, validMoney, _validStock);

        // Assert
        Assert.False(product.IsSuccess);
        Assert.Equal(_nameErrorMessage, product.ErrorMessage);
    }
}
