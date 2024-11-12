namespace Examify.Notification.Hubs;

public interface IResultHub
{
    Task SendMessage(string message);
    Task TestMe(string someRandomText);
}