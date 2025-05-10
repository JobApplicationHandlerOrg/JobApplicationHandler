using JobApplicationHandler.Server.Infrastructure.Middleware;
using JobApplicationHandler.Server.Repositories;
using JobApplicationHandler.Server.Services;

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
        
        //Error and Exception Handling
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
        
        //Logging
        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.AddDebug();
        });
        services.AddHttpLogging();
        
        
        return services;
    }
}