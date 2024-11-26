using System.Text.Json.Serialization;
using AutoMapper;
using Examify.Quiz.Entities;
using Examify.Quiz.Enums;

namespace Examify.Quiz.Features.Quiz.Dtos;

public class QuizDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Cover { get; set; }
    public int Duration { get; set; }
    public List<QuestionDto> Questions { get; set; }
    public bool IsPublished { get; set; }
    public Guid LanguageId { get; set; }
    public string? LanguageName { get; set; }
    public Guid SubjectId { get; set; }
    public string? SubjectName { get; set; }
    public Guid GradeId { get; set; }
    public string? GradeName { get; set; }
    public Guid OwnerId { get; set; }
    public OwnerDto Owner { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public class OwnerDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
    
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public int Duration { get; set; }
        public int Points { get; set; }
        public QuestionType Type { get; set; }
        public int Order { get; set; }
        public List<OptionDto> Options { get; set; }
        
        public class OptionDto
        {
            public Guid Id { get; set; }
            public string Content { get; set; }
            [JsonPropertyName("is_correct")]
            public bool IsCorrect { get; set; }
        }
    }
}

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Entities.Quiz, QuizDto>();
        CreateMap<Question, QuizDto.QuestionDto>();
        CreateMap<Option, QuizDto.QuestionDto.OptionDto>();
    }
}