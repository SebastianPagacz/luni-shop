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
        if (currency.Length != 3)
            throw new Exception();

        return new Money(decimal.Round(value, 2, MidpointRounding.AwayFromZero), currency.ToUpper());
    }
}