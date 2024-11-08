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
    public Guid? OwnerId { get; set; }
    public Visibility Visibility { get; set; } = Visibility.Private;
    
    public List<Question> Questions { get; set; }

    public bool IsPublished { get; set; } = false;
}