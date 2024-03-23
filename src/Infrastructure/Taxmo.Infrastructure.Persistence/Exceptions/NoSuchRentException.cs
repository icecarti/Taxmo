namespace Taxmo.Infrastructure.Persistence.Exceptions;

public class NoSuchRentException : Exception
{
    public NoSuchRentException(string message)
        : base(message) { }
}