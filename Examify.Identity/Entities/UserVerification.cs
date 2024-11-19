namespace Examify.Identity.Entities;

public class UserVerification
{
    public int Id { get; set; }
    public string Token { get; set; }
    
    public string AppUserId { get; set; }
    
    public AppUser AppUser { get; set; }
    
    public DateTime Expires { get; set; }
    public bool IsExpired => DateTime.UtcNow >= Expires;
}