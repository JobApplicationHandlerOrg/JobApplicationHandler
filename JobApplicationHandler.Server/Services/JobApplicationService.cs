using JobApplicationHandler.Contracts.JobApplications;
using JobApplicationHandler.Server.Models.Dto;
using JobApplicationHandler.Server.Models.Dto.MappingExtensions;
using JobApplicationHandler.Server.Repositories;

namespace JobApplicationHandler.Server.Services;

public interface IJobApplicationService
{
    Task<JobApplicationDto?> GetJobApplicationByIdAsync(String id);
    Task<bool> CreateApplicationAsync(JobApplication application);
}
public class JobApplicationService(IJobApplicationRepository jobApplicationRepository): IJobApplicationService
{
    public async Task<JobApplicationDto?> GetJobApplicationByIdAsync(string id)
    {
        var app = await jobApplicationRepository.GetJobApplicationByIdAsync(id);
        return app?.ToDto();
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