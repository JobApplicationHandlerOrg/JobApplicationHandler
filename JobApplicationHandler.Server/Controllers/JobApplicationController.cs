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

    
    [HttpGet]
    public async Task<IEnumerable<JobApplication>> GetJobApplicationById(string applicationId)
    {
        return await jobApplicationService.GetJobApplicationByIdAsync(applicationId);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostJobApplication([FromBody] JobApplication application)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await jobApplicationService.AddApplicationAsync(application);
        return CreatedAtAction(nameof(PostJobApplication), new { id = application.Id }, application);
    }
}
    
