using JobApplicationHandler.Server.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationHandler.Server.Configurations.DBContexts;

public static class DbContextRegistration
{
    public static IServiceCollection AddDbContextRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        
        var jobAppUserDb = configuration.GetConnectionString("JobAppUserDb")
                           ?? throw new InvalidOperationException("Connection string 'JobAppUserDb' not found.");

        var jobApplicationDb = configuration.GetConnectionString("JobApplicationDb")
                               ?? throw new InvalidOperationException("Connection string 'JobApplicationDb' not found.");

        
        services.AddDbContext<JobApplicationDbContext>(options =>
            options.UseSqlServer(jobApplicationDb)); 

        services.AddDbContext<JobAppUserDbContext>(options => 
            options.UseSqlServer(jobAppUserDb)); 
        
        return services;
    }
}