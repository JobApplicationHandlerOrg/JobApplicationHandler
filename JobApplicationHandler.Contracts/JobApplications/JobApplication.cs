using System.ComponentModel.DataAnnotations;

namespace JobApplicationHandler.Contracts.JobApplications;

public class JobApplication
{

    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string CompanyName { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string JobTitle { get; set; }
    
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
    public string ApplicationUrl { get; set; }
    
}