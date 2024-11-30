using Microsoft.AspNetCore.Identity;

namespace Examify.Identity.Entities;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Image { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public List<RefreshToken> RefreshTokens { get; set; }
}