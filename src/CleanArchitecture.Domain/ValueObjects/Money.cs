namespace CleanArchitecture.Domain.ValueObjects;

public class Money
{
    public decimal Amount { get; private set; }
    public string Currency { get; private set; }

    private Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Money Create(decimal amount, string currency = "USD")
    {
        if (amount < 0)
            throw new ArgumentException("El monto no puede ser negativo");

        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException("La moneda no puede estar vacía");

        return new Money(amount, currency.ToUpper());
    }

    public Money Add(Money other)
    {
        if (Currency != other.Currency)
            throw new InvalidOperationException($"No se pueden sumar monedas diferentes: {Currency} y {other.Currency}");

        return new Money(Amount + other.Amount, Currency);
    }

    public Money Subtract(Money other)
    {
        if (Currency != other.Currency)
            throw new InvalidOperationException($"No se pueden restar monedas diferentes: {Currency} y {other.Currency}");

        if (Amount < other.Amount)
            throw new InvalidOperationException("El resultado no puede ser negativo");

        return new Money(Amount - other.Amount, Currency);
    }

    public Money Multiply(int quantity)
    {
        if (quantity < 0)
            throw new ArgumentException("La cantidad no puede ser negativa");

        return new Money(Amount * quantity, Currency);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Money other)
            return false;

        return Amount == other.Amount && Currency == other.Currency;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Amount, Currency);
    }

    public override string ToString()
    {
        return $"{Amount:N2} {Currency}";
    }

    public static implicit operator decimal(Money money) => money.Amount;
}
