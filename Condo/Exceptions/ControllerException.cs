namespace Condo.Exceptions;

public class ControllerException : Exception
{
    public int StatusCode { get; set; }
    public ControllerException(int StatusCode, string Message) : base(Message)
    {
        this.StatusCode = StatusCode;
    }
}