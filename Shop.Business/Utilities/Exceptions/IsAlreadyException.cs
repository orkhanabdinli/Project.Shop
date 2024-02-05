namespace Shop.Business.Utilities.Exceptions;

public class IsAlreadyActive : Exception
{
    public IsAlreadyActive(string message) : base(message)
    {

    }
}
