using Examify.Core.Entitites;
using Examify.Quiz.Enums;

namespace Examify.Quiz.Entities;

public class Quiz : BaseEntity
{
    public string Title { get; set; } = "Untitled Quiz";
    public string? Cover { get; set; }
    public string? Description { get; set; }
    public Guid? SubjectId { get; set; }
    public Guid? GradeId { get; set; }
    public Guid? LanguageId { get; set; }
    public string? OwnerId { get; set; }

    public List<Question> Questions { get; set; }
    public Visibility Visibility { get; set; } = Visibility.Private;

    public bool IsPublished { get; set; } = false;

    public DateTime? PlayTime { get; set; }
    public string? Code { get; set; }
    
    public bool IsStart { get; set; } = false;

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public bool RandomQuestions { get; set; } = false;
    public bool RandomOptions { get; set; } = false;
}