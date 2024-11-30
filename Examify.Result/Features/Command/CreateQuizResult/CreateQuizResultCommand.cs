using FluentValidation;
using MediatR;

namespace Examify.Result.Features.Command.CreateQuizResult;

public record CreateQuizResultCommand : IRequest<IResult>
{
    public Guid QuizId { get; init; }
    
    public string UserId { get; init; }
    
}

public class CreateQuizResultValidator : AbstractValidator<CreateQuizResultCommand>
{
    public CreateQuizResultValidator()
    {
        RuleFor(x => x.QuizId)
            .NotEmpty().WithMessage("QuizId is required");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required");
    }
}
