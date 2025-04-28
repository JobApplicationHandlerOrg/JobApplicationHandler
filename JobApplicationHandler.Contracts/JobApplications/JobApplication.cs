namespace JobApplicationHandler.Contracts.JobApplications;

public class JobApplication
{
    public required string Id { get; set; }
    public required string CompanyName { get; set; }
    public required string JobTitle { get; set; }
    public DateTime ApplicationDate { get; set; }
    public WorkType? WorkType { get; set; }
    public string? Location { get; set; }
    public int? WFHDays { get; set; }
    public required string ApplicationURL { get; set; }
    
}