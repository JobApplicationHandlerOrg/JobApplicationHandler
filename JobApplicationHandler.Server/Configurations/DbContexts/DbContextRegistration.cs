namespace JobApplicationHandler.Server.Configurations.DBContexts;

public static class DbContextRegistration
{
    public static IServiceCollection AddDbContextRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<JobApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("JobAppUserDb")));
        services.AddDbContext<JobAppUserDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("JobApplicationDb")) );
        
        return services;
    }
}