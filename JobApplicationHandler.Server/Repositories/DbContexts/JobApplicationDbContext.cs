using JobApplicationHandler.Contracts.Users;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationHandler.Server.Repositories.DbContexts;

public class JobApplicationDbContext: DbContext
{
    public JobApplicationDbContext(DbContextOptions<JobApplicationDbContext> options) : base(options) { }
    
    public DbSet<JobApplicationUser[]> Users { get; set; }
}