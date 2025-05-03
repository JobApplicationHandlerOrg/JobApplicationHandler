using JobApplicationHandler.Contracts.JobApplications;
using JobApplicationHandler.Server.Repositories;

namespace JobApplicationHandler.Server.Services;

public interface IJobApplicationService
{
    Task<IEnumerable<JobApplication>> GetJobApplicationByIdAsync(String id);
    Task<bool> CreateApplicationAsync(JobApplication application);
}
public class JobApplicationService(IJobApplicationRepository jobApplicationRepository): IJobApplicationService
{
    public async Task<IEnumerable<JobApplication>> GetJobApplicationByIdAsync(String id)
    {
        return await jobApplicationRepository.GetJobApplicationByIdAsync(id);
    }
    
    public async Task<bool> CreateApplicationAsync(JobApplication application)
    {
        //TODO: Cleanup
        try
        {
            await jobApplicationRepository.CreateJobApplicationAsync(application);
            return true; 
        }
        catch (Exception)
        {
            return false; 
        }
    }
}