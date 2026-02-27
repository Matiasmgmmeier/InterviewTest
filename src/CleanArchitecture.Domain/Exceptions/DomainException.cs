namespace CleanArchitecture.Domain.Exceptions;

public class DomainException : Exception
{
    public DomainException(string message) : base(message)
    {
    }

    public DomainException(string message, Exception innerException) 
        : base(message, innerException)
    {
    }
}

public class EntityNotFoundException : DomainException
{
    public EntityNotFoundException(string entityName, object id)
        : base($"{entityName} con ID {id} no fue encontrado")
    {
    }
}

public class BusinessRuleValidationException : DomainException
{
    public BusinessRuleValidationException(string rule)
        : base($"Regla de negocio violada: {rule}")
    {
    }
}

public class InvalidEntityStateException : DomainException
{
    public InvalidEntityStateException(string message)
        : base(message)
    {
    }
}
