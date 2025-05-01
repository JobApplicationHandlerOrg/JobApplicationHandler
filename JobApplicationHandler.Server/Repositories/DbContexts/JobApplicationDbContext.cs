using JobApplicationHandler.Contracts.JobApplications;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationHandler.Server.Repositories.DbContexts;

public class JobApplicationDbContext(DbContextOptions<JobApplicationDbContext> options) : DbContext(options)
{
    public DbSet<JobApplication> JobApplications { get; set; }  
}