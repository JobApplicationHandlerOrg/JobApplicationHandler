using JobApplicationHandler.Contracts.Users;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationHandler.Server.Repositories.DbContexts;

public class JobAppUserDbContext(DbContextOptions<JobApplicationDbContext> options) : DbContext(options)
{
public DbSet<JobApplicationUser> Users { get; set; }  
}