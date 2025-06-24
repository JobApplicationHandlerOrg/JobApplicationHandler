﻿using JobApplicationHandler.Contracts.JobApplications;
using JobApplicationHandler.Server.Infrastructure.Middleware;
using JobApplicationHandler.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace JobApplicationHandler.Contracts.JobApplications
{
    public interface IJobApplicationController
    {
        Task<ActionResult<JobApplication>> GetJobApplicationByIdAsync(String id);
        Task<IActionResult> CreateApplicationAsync(JobApplication application);
    }
}

[ApiController]
[Route("api/jobapplication")]
public class JobApplicationController(IJobApplicationService jobApplicationService): Controller, IJobApplicationController
{
    
    [HttpGet("{id}")]
    public async Task<ActionResult<JobApplication>> GetJobApplicationByIdAsync(String id)
    {
        var application = await jobApplicationService.GetJobApplicationByIdAsync(id);

        return Ok(application);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateApplicationAsync([FromBody] JobApplication application)
    {
        if (!ModelState.IsValid)
        {
            throw new ProblemException("The model is invalid.", "Test", 400);
        }
        //TODO: cleanup
        var result = await jobApplicationService.CreateApplicationAsync(application);
    
        return result ? Ok() : throw new ProblemException("Something went wrong", "An error has occured that was not expected", 500);
    }
    

}
    
