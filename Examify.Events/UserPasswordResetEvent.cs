namespace Examify.Events;

public class UserPasswordResetEvent
{
    public string UserId { get; set; }
    public string Email { get; set; }
    public string ResetLink { get; set; }
}