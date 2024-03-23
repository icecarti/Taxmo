namespace Taxmo.Infrastructure.Persistence.Exceptions;

public class NoSuchParkException : Exception
{
    public NoSuchParkException(string message)
        : base(message) { }
}