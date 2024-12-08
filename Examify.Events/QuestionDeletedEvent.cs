namespace Examify.Events;
public class QuestionDeletedEvent
{
    public Guid QuestionId { get; set; }
    public DateTime DeletedAt { get; set; }
}
