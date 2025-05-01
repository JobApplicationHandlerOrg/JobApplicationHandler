namespace JobApplicationHandler.Contracts.Users;

public class JobApplicationUser
{
    public required string Id { get; init; }
    public required string Username { get; init; }
    public required string Password { get; init; }
    public UserRoles UserRoles { get; init; }
    public DateTime RegistrationDate { get; init; } = DateTime.Now;
    public DateTime? LastLoginDate { get; set; } = DateTime.Now;
    

}
