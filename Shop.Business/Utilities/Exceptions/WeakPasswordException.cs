namespace Shop.Business.Utilities.Exceptions;

public class WeakPasswordException : Exception
{
    public WeakPasswordException(string message) : base(message)
    {

    }
}
