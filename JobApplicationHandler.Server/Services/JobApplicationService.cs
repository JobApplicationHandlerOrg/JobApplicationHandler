using JobApplicationHandler.Contracts.JobApplications;
using JobApplicationHandler.Server.Repositories;

namespace JobApplicationHandler.Server.Services;

public interface IJobApplicationService
{
    public Task<IEnumerable<JobApplication>> GetJobApplicationByIdAsync(string id);
}
public class JobApplicationService(JobApplicationRepository jobApplicationRepository): IJobApplicationService
{
    public async Task<IEnumerable<JobApplication>> GetJobApplicationByIdAsync(string id)
    {
        return await jobApplicationRepository.GetJobApplicationByIdAsync(id);
    }
}