namespace Examify.Identity.Dtos;

public class AuthenticatedDto
{
    public string Id { get; set; }
    
    public string FullName { get; set; }
    
    public string Email { get; set; }
    
    public string Token { get; set; }
    public int ExpiresIn { get; set; }
    public string RefreshToken { get; set; }
}