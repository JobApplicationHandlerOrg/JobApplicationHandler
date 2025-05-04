namespace JobApplicationHandler.Server.Configurations.Extensions.Configuration;

public static class ConfigRegistration
{
    public static IConfigurationBuilder AddDConfigurationSettings(this IConfigurationBuilder configuration, IHostEnvironment env)
    {
        configuration
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
        
        if (env.IsDevelopment())
        {
            configuration.AddUserSecrets<Program>();
        }
        
        return configuration;
    }
}