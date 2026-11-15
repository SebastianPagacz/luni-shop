using LuniShop.Shared.Abstractions.Results;

namespace LuniShop.Module.Products.Core.Domain.Primitives;

public record Money
{
    public decimal Amount { get; init; }
    public string Currency { get; init; } = string.Empty;

    private Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Result<Money> CreatePln(decimal amount)
    {
        if (amount <= 0)
            return Result.Failure<Money>("Amount can't be 0 or below.");

        return Result.Success(new Money(Math.Round(amount, 2, MidpointRounding.AwayFromZero), "PLN"));
    }
}
