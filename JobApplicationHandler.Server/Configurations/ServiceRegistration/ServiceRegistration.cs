using JobApplicationHandler.Server.Repositories;
using JobApplicationHandler.Server.Services;

namespace JobApplicationHandler.Server.Configurations.ServiceRegistration;

public static class ServiceRegistration
{
    public static IServiceCollection AddServiceRegistration(this IServiceCollection services,
        IConfiguration configuration)
    {
        
        
        services.AddScoped<IJobApplicationService, JobApplicationService>();
        
        
        services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
        
        return services;
    }
}