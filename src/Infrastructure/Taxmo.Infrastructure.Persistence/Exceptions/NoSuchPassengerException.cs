namespace Taxmo.Infrastructure.Persistence.Exceptions;
public class NoSuchPassengerException : Exception
{
    public NoSuchPassengerException(string message)
        : base(message) { }
}
