namespace Examify.Events;
public class QuizDeletedEvent
{
    public Guid QuizId { get; set; }

    public DateTime DeletedAt { get; set; }
}
