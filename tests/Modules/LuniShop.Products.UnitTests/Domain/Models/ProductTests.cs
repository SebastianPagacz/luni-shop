using LuniShop.Module.Products.Core.Domain.Models;
using LuniShop.Module.Products.Core.Domain.Primitives;

namespace LuniShop.Products.UnitTests.Domain.Models;

public class ProductTests
{
    public const string ValidName = "TestProduct";
    public const int ValidStock = 10;

    [Fact]
    public void CreateProduct_ShouldReturnSuccessfulResult_WhenProvidingValidData()
    {
        // Arrange
        var validMoney = Money.CreatePln(100).Value!; // This is definetly not null

        // Act
        var product = Product.CreateProduct(ValidName, validMoney, ValidStock);

        // Assert
        Assert.True(product.IsSuccess);
        Assert.Null(product.ErrorMessage);
        Assert.Equal(ValidName, product.Value.Name);
        Assert.Equal(ValidStock, product.Value.Stock);
    }
}
