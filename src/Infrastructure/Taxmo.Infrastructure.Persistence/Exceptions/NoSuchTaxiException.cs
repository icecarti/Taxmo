namespace Taxmo.Infrastructure.Persistence.Exceptions;

public class NoSuchTaxiException : Exception
{
    public NoSuchTaxiException(string message)
        : base(message) { }
}