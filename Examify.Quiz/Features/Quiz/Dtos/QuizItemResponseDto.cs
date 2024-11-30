using AutoMapper;
using Examify.Quiz.Enums;
using Quiz;
using Visibility = Examify.Quiz.Enums.Visibility;

namespace Examify.Quiz.Features.Quiz.Dtos;

public class QuizItemResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Cover { get; set; }
    public string? Description { get; set; }
    public SubjectDto? Subject { get; set; }
    public GradeDto? Grade { get; set; }
    public LanguageDto? Language { get; set; }
    public OwnerDto? Owner { get; set; }
    public Visibility Visibility { get; set; }
    public int Duration { get; set; }
    public int QuestionCount { get; set; }
    public int AttemptCount { get; set; }
    
    public string Code { get; set; }
}

public class QuizProfile : Profile
{
    public QuizProfile()
    {
        CreateMap<Entities.Quiz, QuizItemResponseDto>()
            .ForMember(dest => dest.QuestionCount,
                opt => opt.MapFrom(src => src.Questions.Count))
            .ForMember(dest => dest.Duration,
                opt
                    => opt.MapFrom(src => src.Questions.Sum(x => x.Duration)))
            .ForMember(dest => dest.Subject,
                opt => opt.MapFrom(src => new SubjectDto
                {
                    Id = src.SubjectId,
                }))
            .ForMember(dest => dest.Language,
                opt => opt.MapFrom(src => new LanguageDto
                {
                    Id = src.LanguageId,
                }))
            .ForMember(dest => dest.Grade,
                opt => opt.MapFrom(src => new GradeDto
                {
                    Id = src.GradeId,
                }))
            .ForMember(dest => dest.Owner,
                opt => opt.MapFrom(src => new OwnerDto
                {
                    Id = src.OwnerId,
                }))
            ;
    }
}

public class SubjectDto
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
}

public class GradeDto
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
}

public class LanguageDto
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
}

public class OwnerDto
{
    public string? Id { get; set; }
    public string FullName { get; set; }
    public string Image { get; set; }
}