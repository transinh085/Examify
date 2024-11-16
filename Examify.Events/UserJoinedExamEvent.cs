namespace Examify.Events;

public class UserJoinedExamEvent
{
    public string UserId { get; set; }
    public Guid ExamId { get; set; }
}