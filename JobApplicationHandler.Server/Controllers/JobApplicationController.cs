using JobApplicationHandler.Contracts.JobApplications;
using JobApplicationHandler.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationHandler.Server.Controllers;

[ApiController]
[Authorize]
[Route("[controller]/[action]")]
public class JobApplicationController(IJobApplicationService jobApplicationService): Controller
{

    
    public  Task<JobApplication> GetJobApplicationById(string applicationId)
    {
        return jobApplicationService.GetJobApplicationByIdAsync(applicationId);
    }
}