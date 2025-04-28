using JobApplicationHandler.Contracts.JobApplications;

namespace JobApplicationHandler.Server.Repositories;

public interface IJobApplicationRepository
{
    public Task<IEnumerable<JobApplication>> GetJobApplicationByIdAsync();
}

public class JobApplicationRepository: IJobApplicationRepository
{
    public Task<IEnumerable<JobApplication>> GetJobApplicationByIdAsync()
    {
        return Context GetJobApplicationsByIdAsync();
    }
}