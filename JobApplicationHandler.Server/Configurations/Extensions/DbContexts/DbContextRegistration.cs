using JobApplicationHandler.Server.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationHandler.Server.Configurations.Extensions.DbContexts;

public static class DbContextRegistration
{
    public static IServiceCollection AddDbContextRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        var jobAppUserConn = BuildPostgresConnectionString(configuration, "JobAppUserDbName");
        var jobApplicationConn = BuildPostgresConnectionString(configuration, "JobApplicationDbName");

        services.AddDbContext<JobApplicationDbContext>(options =>
            options.UseNpgsql(jobApplicationConn));

        services.AddDbContext<JobAppUserDbContext>(options =>
            options.UseNpgsql(jobAppUserConn));

        return services;
    }

    private static string BuildPostgresConnectionString(IConfiguration config, string dbNameKey)
    {
        
        var host = config["ConnectionStrings:PostgresDbHost"];
        var port = config["ConnectionStrings:PostgresDbPort"] ;
        var username = config["ConnectionStrings:PostgresDbUsername"] 
                       ?? throw new InvalidOperationException("PostgresDbUsername not set.");
        var password = config["ConnectionStrings:PostgresDbPassword"] 
                       ?? throw new InvalidOperationException("PostgresDbPassword not set.");
        var database = config[$"ConnectionStrings:{dbNameKey}"] 
                       ?? throw new InvalidOperationException($"{dbNameKey} not set.");

        return $"Host={host};Port={port};Database={database};Username={username};Password={password};";
    }
}