using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationHandler.Server.Infrastructure.Middleware;

[Serializable]
public class ProblemException(string error, string errorMessage) : Exception(errorMessage)
{
    public string Error { get; } = error;
    public string ErrorMessage { get; } = errorMessage;
}

public class GlobalExceptionHandler(
    ILogger<GlobalExceptionHandler> logger,
    IProblemDetailsService problemDetailsService) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ProblemException problemException)
            return false; 

        var problemDetails = new ProblemDetails
        {
            Detail = problemException.ErrorMessage,
            Status = StatusCodes.Status500InternalServerError,
            Type = "/error/internal",
            Title = problemException.Error
        };

        logger.LogError(
            "An exception has occurred: {Exception}. Message: {Message}. Request Path: {RequestPath}",
            exception, exception.Message, httpContext.Request.Path);

        return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            ProblemDetails = problemDetails
        });
    }

}
