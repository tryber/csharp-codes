using Condo.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Condo.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception != null)
        {
            var messageResponse = "Server error";
            var statusCodeResponse = 500;

            if (context.Exception is ControllerException controllerException)
            {
                messageResponse = controllerException.Message;
                statusCodeResponse = controllerException.StatusCode;
            }

            var response = new { Message = messageResponse };
            context.Result = new ObjectResult(response)
            {
                StatusCode = statusCodeResponse
            };
            context.ExceptionHandled = true;
        }
    }
}