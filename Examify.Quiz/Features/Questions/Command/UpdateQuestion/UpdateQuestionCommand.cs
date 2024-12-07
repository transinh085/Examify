using AutoMapper;
using Examify.Quiz.Entities;
using Examify.Quiz.Enums;
using FluentValidation;
using MediatR;
using System.Text.Json.Serialization;

namespace Examify.Quiz.Features.Questions.Command.UpdateQuestion;

public record UpdateQuestionCommand(Guid Id, Guid quizId, string Content, int Duration, int Points, QuestionType Type, int Order, List<UpdateOptionsDto> Options) : IRequest<IResult>;

public record UpdateOptionsDto
{
    public Guid Id { get; init; }
    public string Content { get; init; }

    [JsonPropertyName("is_correct")]
    public bool IsCorrect { get; init; }
}

public class UpdateQuestionMappingProfile : Profile
{
    public UpdateQuestionMappingProfile()
    {
        CreateMap<UpdateQuestionCommand, Question>()
            .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options));
        CreateMap<UpdateOptionsDto, Option>();
    }
}

public class UpdateQuestionValidator : AbstractValidator<UpdateQuestionCommand>
{
    public UpdateQuestionValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Content).NotEmpty();
        RuleFor(x => x.Duration).GreaterThan(0);
        RuleFor(x => x.Points).GreaterThan(0);
        RuleFor(x => x.Type).IsInEnum();
        RuleFor(x => x.Order).GreaterThan(0);
        RuleFor(x => x.Options).NotEmpty();
        RuleForEach(x => x.Options).SetValidator(new UpdateAnswerValidator());
    }
}

public class UpdateAnswerValidator : AbstractValidator<UpdateOptionsDto>
{
    public UpdateAnswerValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Content).NotEmpty();
    }
}

