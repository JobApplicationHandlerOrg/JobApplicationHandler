using JobApplicationHandler.Contracts.JobApplications;

namespace JobApplicationHandler.Server.Models.Dto.MappingExtensions;


public static class JobApplicationMappingExtensions
{
    public static JobApplicationDto ToDto(this JobApplication entity)
    {
        return new JobApplicationDto
        {
            Id = entity.Id,
            CompanyName = entity.CompanyName,
            JobTitle = entity.JobTitle,
            ApplicationDate = entity.ApplicationDate,
            WorkType = entity.WorkType,
            Location = entity.Location,
            OnLocationInDays = entity.OnLocationInDays,
            ApplicationUrl = entity.ApplicationUrl
        };
    }
    
    public static IEnumerable<JobApplicationDto> ToDtoList(this IEnumerable<JobApplication> entities)
    {
        return entities.Select(e => e.ToDto());
    }
    
    public static JobApplication ToEntity(this JobApplicationDto dto)
    {
        return new JobApplication
        {
            Id = dto.Id,
            CompanyName = dto.CompanyName,
            JobTitle = dto.JobTitle,
            ApplicationDate = dto.ApplicationDate,
            WorkType = dto.WorkType,
            Location = dto.Location,
            OnLocationInDays = dto.OnLocationInDays,
            ApplicationUrl = dto.ApplicationUrl
        };
    }
    
    
}