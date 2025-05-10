using JobApplicationHandler.Contracts.JobApplications;

namespace JobApplicationHandler.Server.Models.Dto;

public class JobApplicationDto
{
    public string Id { get; set; } = default!;
    public string CompanyName { get; set; } = default!;
    public string JobTitle { get; set; } = default!;
    public DateTime ApplicationDate { get; set; }
    public WorkType? WorkType { get; set; }
    public string? Location { get; set; }
    public int? OnLocationInDays { get; set; }
    public string ApplicationUrl { get; set; } = default!;
}