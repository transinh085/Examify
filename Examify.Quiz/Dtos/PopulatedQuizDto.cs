using System.Text.Json.Serialization;
using AutoMapper;
using Examify.Quiz.Entities;
using Examify.Quiz.Enums;

namespace Examify.Quiz.Dtos;

public class PopulatedQuizDto
{
    public Guid Id { get; set; }
    public List<PopulatedQuestionDto> Questions { get; set; }
    
    public class PopulatedQuestionDto
    {
        public Guid Id { get; set; }
        
        public string Content { get; set; }
    
        public int Duration { get; set; }
        public QuestionType Type { get; set; }
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
        CreateMap<Entities.Quiz, PopulatedQuizDto>();
        CreateMap<Question, PopulatedQuizDto.PopulatedQuestionDto>();
        CreateMap<Option, PopulatedQuizDto.PopulatedQuestionDto.OptionDto>();
    }
}