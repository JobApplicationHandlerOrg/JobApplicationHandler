namespace JobApplicationHandler.Contracts.Users;

public class JobApplicationUser
{
    public required string Id { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public UserRoles UserRoles { get; set; }
        
    
    
}
