namespace Examify.Result.Interfaces;

public interface IResultHub
{
    Task SendMessage(string message);
    Task TestMe(string someRandomText);
}