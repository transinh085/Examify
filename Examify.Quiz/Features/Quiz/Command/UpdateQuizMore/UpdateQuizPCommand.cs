using AutoMapper;
using Examify.Quiz.Enums;
using Examify.Quiz.Infrastructure.Data;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Quiz.Command.UpdateQuizMore;

public record UpdateQuizPCommand : IRequest<IResult>
{
    public Guid Id { get; init; }
    public string StartTime { get; init; }
    public string EndTime { get; init; }
    public bool RandomQuestions { get; init; }
    public bool RandomOptions { get; init; } 
}

public class UpdateQuizPValidator : AbstractValidator<UpdateQuizPCommand>
{
    public UpdateQuizPValidator(QuizContext context)
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .MustAsync((id, cancellationToken) =>
                context.Quizzes.AnyAsync(x => x.Id == id, cancellationToken)
            ).WithMessage("Quiz with this id does not exist");
    }
}

// config mapper 
public class UpdateQuizPMapper : Profile
{
    public UpdateQuizPMapper()
    {
        CreateMap<UpdateQuizPCommand, Entities.Quiz>();
    }
}