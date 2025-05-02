using System.ComponentModel.DataAnnotations;

namespace JobApplicationHandler.Contracts.JobApplications;

public class JobApplication
{

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Id { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public required string CompanyName { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public required string JobTitle { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Application Date")]
    public DateTime ApplicationDate { get; set; }
    
    public WorkType? WorkType { get; set; }
    
    [StringLength(100)]
    public string? Location { get; set; }
    
    [Range(0, 5, ErrorMessage = "OnLocationInDays must be between 0 and 5.")]
    public int? OnLocationInDays { get; set; }
    
    [Required]
    [Url(ErrorMessage = "ApplicationUrl must be a valid URL.")]
    public required string ApplicationUrl { get; set; }
    
}