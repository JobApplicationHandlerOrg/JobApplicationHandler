using JobApplicationHandler.Contracts.JobApplications;
using JobApplicationHandler.Server.Models.Dto.MappingExtensions;
using JobApplicationHandler.Server.Repositories;
using JobApplicationHandler.Server.Services;
using Moq;

namespace JobApplicationHandler.Tests.ServiceTests;

public class JobApplicationServiceTests
{
    private readonly Mock<IJobApplicationRepository> _mockRepo;
    private readonly JobApplicationService _service;

    public JobApplicationServiceTests()
    {
        _mockRepo = new Mock<IJobApplicationRepository>();
        _service = new JobApplicationService(_mockRepo.Object);
    }

    [Fact]
    public async Task AssertThatJobApplicationExists()
    {
        // Arrange
        const string fakeId = "123";

        var expectedApplication = new JobApplication
        {
            Id = fakeId,
            CompanyName = "Company",
            JobTitle = ".Net Software Developer",
            ApplicationUrl = "ApplicationUrl.com"
        };

        
        var expectedDto = expectedApplication.ToDto();

        
        _mockRepo.Setup(repo => repo.GetJobApplicationByIdAsync(fakeId))
            .ReturnsAsync(expectedApplication);

        // Act
        var result = await _service.GetJobApplicationByIdAsync(fakeId);

        // Assert
        Assert.Equal(".Net Software Developer", result.JobTitle);
    }

}
