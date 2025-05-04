

namespace JobApplicationHandler.Tests.SecretsTests;

public class SecretsTests
{
    [Fact]
    public void Secrets_AreNotNullOrEmpty()
    {
        
        var host = Environment.GetEnvironmentVariable("ConnectionStrings__PostgresDbHost");
        var port = Environment.GetEnvironmentVariable("ConnectionStrings__PostgresDbPort");
        var username = Environment.GetEnvironmentVariable("ConnectionStrings__PostgresDbUsername");
        var password = Environment.GetEnvironmentVariable("ConnectionStrings__PostgresDbPassword");
        var jobAppUserDbName = Environment.GetEnvironmentVariable("ConnectionStrings__JobAppUserDbName");
        var jobApplicationDbName = Environment.GetEnvironmentVariable("ConnectionStrings__JobApplicationDbName");

        
        Assert.False(string.IsNullOrEmpty(host), "PostgresDbHost secret is null or empty");
        Assert.False(string.IsNullOrEmpty(port), "PostgresDbPort secret is null or empty");
        Assert.False(string.IsNullOrEmpty(username), "PostgresDbUsername secret is null or empty");
        Assert.False(string.IsNullOrEmpty(password), "PostgresDbPassword secret is null or empty");
        Assert.False(string.IsNullOrEmpty(jobAppUserDbName), "JobAppUserDbName secret is null or empty");
        Assert.False(string.IsNullOrEmpty(jobApplicationDbName), "JobApplicationDbName secret is null or empty");
    }
}
