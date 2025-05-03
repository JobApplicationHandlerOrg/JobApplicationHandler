using System.ComponentModel.DataAnnotations;

namespace JobApplicationHandler.Contracts.JobApplications;

public class JobApplication
{

    [Key]
    public string Id { get; } = Guid.NewGuid().ToString();
    
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public required string CompanyName { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public required string JobTitle { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Application Date")]
    public DateTime ApplicationDate { get; init; } = DateTime.UtcNow;
    
    public WorkType? WorkType { get; set; }
    
    [StringLength(100)]
    public string? Location { get; set; }
    
    [Range(0, 7, ErrorMessage = "OnLocationInDays must be between 0 and 7.")]
    public int? OnLocationInDays { get; set; }
    
    [Required]
    [Url(ErrorMessage = "ApplicationUrl must be a valid URL.")]
    public required string ApplicationUrl { get; set; }
    
}