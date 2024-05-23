namespace Condo.Exceptions;

public class BadRequestException : ControllerException
{
    public BadRequestException(string Message) : base(400, Message)
    {}
}