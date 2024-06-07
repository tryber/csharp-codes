using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;

namespace Condo.Filters;

public class AuthorizationFilter : IAuthorizationMiddlewareResultHandler
{
    private readonly AuthorizationMiddlewareResultHandler _handler;
    public AuthorizationFilter()
    {
        _handler = new AuthorizationMiddlewareResultHandler();
    }
    public async Task HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult)
    {
        if (authorizeResult.Challenged) {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            var json = JsonSerializer.Serialize(new { Message = "Invalid Token"});
            await context.Response.Body.WriteAsync(Encoding.ASCII.GetBytes(json));
            return;
        }
        if (authorizeResult.Forbidden) {
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            var json = JsonSerializer.Serialize(new { Message = "Invalid Token"});
            await context.Response.Body.WriteAsync(Encoding.ASCII.GetBytes(json));
            return;
        }

        await _handler.HandleAsync(next, context, policy, authorizeResult);
    }
}