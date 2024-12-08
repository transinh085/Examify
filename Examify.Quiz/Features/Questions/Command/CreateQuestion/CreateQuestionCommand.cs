using AutoMapper;
using Examify.Quiz.Entities;
using Examify.Quiz.Enums;
using FluentValidation;
using MediatR;
using System.Text.Json.Serialization;

namespace Examify.Quiz.Features.Questions.Command.CreateQuestion;

public record CreateQuestionCommand : IRequest<IResult>
{
    public string Content { get; init; }

    public int Duration { get; init; }

    public int Points { get; init; }

    public QuestionType Type { get; init; }

    public int Order { get; init; }

    public Guid QuizId { get; init; }

    public List<CreateOptionsDto> Options { get; init; }
}

public record CreateOptionsDto
{
    public string Content { get; set; }

    [JsonPropertyName("is_correct")]
    public bool IsCorrect { get; set; }
}

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateQuestionCommand, Question>()
            .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options));
        CreateMap<CreateOptionsDto, Option>();
    }
}

public class CreateQuestionValidator : AbstractValidator<CreateQuestionCommand>
{
    public CreateQuestionValidator()
    {
        RuleFor(x => x.Content).NotEmpty();
        RuleFor(x => x.Duration).GreaterThan(0);
        RuleFor(x => x.Points).GreaterThan(0);
        RuleFor(x => x.Type).IsInEnum();
        RuleFor(x => x.QuizId).NotEmpty();
        RuleFor(x => x.Options).NotEmpty();
        RuleForEach(x => x.Options).SetValidator(new CreateAnswerValidator());
    }
}

public class CreateAnswerValidator : AbstractValidator<CreateOptionsDto>
{
    public CreateAnswerValidator()
    {
        RuleFor(x => x.Content).NotEmpty();
        RuleFor(x => x.IsCorrect).NotNull();
    }
}