using AutoMapper;

namespace Examify.Quiz.Features.Quiz.Dtos;

public class QuizUserDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Cover { get; set; }
    public int Duration { get; set; }
    public int NumberQuestions { get; set; }
    public bool IsPublished { get; set; }
    public LanguageDto? Language { get; set; }
    public SubjectDto? Subject { get; set; }
    public GradeDto? Grade { get; set; }
    public OwnerDto? Owner { get; set; }
    
    public class OwnerDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
    
    public class LanguageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    
    public class SubjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    
    public class GradeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}