namespace Condo.Exceptions;

public class ForbiddenException : ControllerException
{
    public ForbiddenException(string Message) : base(403, Message)
    {}
}