using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationHandler.Server.Infrastructure.Middleware;

public class GlobalExceptionHandler: IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        
        //TODO: Log something

        var problemDetails = new ProblemDetails
        {
            Detail = exception.Message,
            Status = StatusCodes.Status500InternalServerError,
            Type = "/error/500",
            Title = "This is a test error",
        };
        httpContext.Response.StatusCode = problemDetails.Status.Value;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }
}