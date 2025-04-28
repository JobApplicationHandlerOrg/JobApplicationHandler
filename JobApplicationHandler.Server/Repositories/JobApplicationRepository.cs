using JobApplicationHandler.Contracts.JobApplications;

namespace JobApplicationHandler.Server.Repositories;

public interface IJobApplicationRepository
{
    public Task<IEnumerable<JobApplication>> GetJobApplicationByIdAsync(string id);
}

public class JobApplicationRepository: IJobApplicationRepository
{
    public async Task<IEnumerable<JobApplication>> GetJobApplicationByIdAsync(string id)
    {
        return await Context GetJobApplicationsByIdAsync(id);
    }
}