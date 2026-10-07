namespace ProductModule.Domain.ValueObjects;

public record Money
{
    private Money(decimal value, string currency)
    {
        Value = value;
        Currency = currency;
    }

    public decimal Value { get; private set; }
    public string Currency { get; private set; }

    public Money Create(decimal value, string currency)
    {
        return new Money(decimal.Round(value, 2, MidpointRounding.AwayFromZero), currency);
    }
}