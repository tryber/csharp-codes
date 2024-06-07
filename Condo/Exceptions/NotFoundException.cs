namespace Condo.Exceptions;

public class NotFoundException : ControllerException
{
    public NotFoundException(string Message) : base(404, Message)
    {}
}