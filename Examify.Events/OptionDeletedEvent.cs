namespace Examify.Events;
public class OptionDeletedEvent
{
    public List<Guid> OptionIds { get; set; } = new();
    public DateTime DeletedAt { get; set; }
}
