namespace Taxmo.Infrastructure.Persistence.Exceptions;

public class NoSuchWorkSheetException : Exception
{
    public NoSuchWorkSheetException(string message)
        : base(message) { }
}