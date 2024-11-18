namespace Examify.Events;

public class UserVerificationEmailEvent
{
    public string UserId { get; set; }
    public string Email { get; set; }
    public string VerificationLink { get; set; }
}