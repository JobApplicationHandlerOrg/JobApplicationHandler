using JobApplicationHandler.Server.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationHandler.Server.Configurations.DBContexts;

public static class DbContextRegistration
{
    public static IServiceCollection AddDbContextRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        var jobAppUserDb =
            configuration.GetConnectionString("JobApplicationDb")
            ?? throw new InvalidOperationException("Connection string"
                                                   + "'JobAppUserDb' not found.");
        var jobApplicationDb =
            configuration.GetConnectionString("JobAppUserDb")
            ?? throw new InvalidOperationException("Connection string"
                                                   + "'JobApplicationDb' not found.");
       
        services.AddDbContext<JobApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString(jobAppUserDb)));
        services.AddDbContext<JobAppUserDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString(jobApplicationDb)) );
        
        return services;
    }
}