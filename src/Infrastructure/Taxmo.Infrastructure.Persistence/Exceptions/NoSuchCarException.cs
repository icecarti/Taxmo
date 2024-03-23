namespace Taxmo.Infrastructure.Persistence.Exceptions;

public class NoSuchCarException : Exception
{
    public NoSuchCarException(string message)
        : base(message) { }
}