using JobApplicationHandler.Contracts.JobApplications;
using JobApplicationHandler.Server.Repositories;

namespace JobApplicationHandler.Server.Services;

public interface IJobApplicationService
{
    Task<IEnumerable<JobApplication>> GetJobApplicationByIdAsync(string id);
    Task AddApplicationAsync(JobApplication application);
}
public class JobApplicationService(IJobApplicationRepository jobApplicationRepository): IJobApplicationService
{
    public async Task<IEnumerable<JobApplication>> GetJobApplicationByIdAsync(string id)
    {
        return await jobApplicationRepository.GetJobApplicationByIdAsync(id);
    }
    
    public async Task AddApplicationAsync(JobApplication application)
    {
        // Business logic/validation can go here
        await jobApplicationRepository.CreateJobApplicationAsync(application);
    }
}