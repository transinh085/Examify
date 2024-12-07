namespace Examify.Result.Dtos;

public class QuizRecentActivityDto
{
    public Guid Id { get; set; }
    public Guid QuizId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public string Cover { get; set; }
    public int QuestionCount { get; set; }
    public int AttemptedNumber { get; set; }
    public decimal CurrentProgress { get; set; }
    public DateTime CreatedDate { get; set; }
}