namespace Shop.Business.Utilities.Exceptions;

public class AlreadyExistsException : Exception
{
    public AlreadyExistsException(string message) : base(message)
    {

    }
}
