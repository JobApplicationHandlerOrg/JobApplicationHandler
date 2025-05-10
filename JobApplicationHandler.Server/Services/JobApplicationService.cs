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
public class JobApplicationService(IJobApplicationRepository jobApplicationRepository, ILogger<JobApplicationService> _logger): IJobApplicationService
{
    
    //TODO: is this correct? Write some tests for it.
    public async Task<JobApplicationDto?> GetJobApplicationByIdAsync(string id)
    {
        try
        {
            var app = await jobApplicationRepository.GetJobApplicationByIdAsync(id);
            return app?.ToDto();
        }
        catch (Exception ex)
        {
            _logger.LogInformation("Could not find the resource related to the ID {id}, ", id);
            throw;
        }
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