namespace CleanArchitecture.Domain.ValueObjects;

public class Email
{
    public string Value { get; private set; }

    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("El email no puede estar vacío");

        if (!email.Contains("@"))
            throw new ArgumentException("El email debe contener @");

        if (email.Length > 100)
            throw new ArgumentException("El email no puede tener más de 100 caracteres");

        return new Email(email.ToLower().Trim());
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Email other)
            return false;

        return Value == other.Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(Email email) => email.Value;
}
