namespace Condo.Exceptions;

public class UnauthorizedException : ControllerException
{
    public UnauthorizedException(string Message) : base(401, Message)
    {}
}