using JobApplicationHandler.Contracts.JobApplications;
using JobApplicationHandler.Server.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationHandler.Server.Repositories;

public interface IJobApplicationRepository
{
    public Task<IEnumerable<JobApplication>> GetJobApplicationByIdAsync(string id);
}

public class JobApplicationRepository(JobApplicationDbContext dbContext) : IJobApplicationRepository
{
    private readonly JobApplicationDbContext _dbContext = dbContext;

    public async Task<IEnumerable<JobApplication>> GetJobApplicationByIdAsync(string id)
    {
        return await _dbContext.JobApplications
            .Where(j => j.Id == id)
            .ToListAsync();
    }
}