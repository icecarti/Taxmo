namespace Taxmo.Infrastructure.Persistence.Exceptions;
public class NoSuchOrderException : Exception
{
    public NoSuchOrderException(string message)
        : base(message) { }
}
