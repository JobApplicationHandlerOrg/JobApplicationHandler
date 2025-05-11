using System.Text.Json.Serialization;
using JobApplicationHandler.Server.Infrastructure.Middleware;
using JobApplicationHandler.Server.Repositories;
using JobApplicationHandler.Server.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationHandler.Server.Configurations.Extensions.ServiceRegistration;

public static class ServiceRegistration
{
    public static IServiceCollection AddServiceRegistration
        (
        this IServiceCollection services,
        IConfiguration configuration
        )
    {
        
        services.AddScoped<IJobApplicationService, JobApplicationService>();
        services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
        
        //Logging
        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.AddDebug();
        });
        services.AddHttpLogging();
        
        //Error and Exception Handling
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails(options =>
            options.CustomizeProblemDetails = context =>
            {
                context.ProblemDetails.Instance =
                    $"{context.HttpContext.Request.Method}:{context.HttpContext.Request.Path}";
                context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);

                context.ProblemDetails.Extensions.TryAdd("traceId",
                    context.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity.Id);
                
            });
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var errors = context.ModelState
                    .Where(e => e.Value?.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                var validationProblem = new ValidationProblemDetails(errors)
                {
                    Title = "Validation failed",
                    Status = StatusCodes.Status400BadRequest,
                    Type = "/error/validation",
                    Detail = "Check the 'errors' property for more information.",
                    Instance = context.HttpContext.Request.Path
                };

                return new ObjectResult(validationProblem)
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            };
        });

        services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(e => e.Value?.Errors.Count > 0)
                        .ToDictionary(
                            kvp => kvp.Key, 
                            kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
                        );

                    var validationProblem = new ValidationProblemDetails(errors)
                    {
                        Title = "Validation failed",
                        Status = StatusCodes.Status400BadRequest,
                        Type = "/error/validation",
                        Detail = "Check the 'errors' property for more information.",
                        Instance = context.HttpContext.Request.Path
                    };

                    return new BadRequestObjectResult(validationProblem);
                };
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        
        
        return services;
    }
}