using FluentValidation;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.DeleteQuiz;

public record DeleteQuizCommand(Guid QuizId) : IRequest<IResult>;

public class DeleteQuizValidator : AbstractValidator<DeleteQuizCommand>
{
    public DeleteQuizValidator()
    {
        RuleFor(x => x.QuizId)
            .NotEmpty().WithMessage("Id is required");
    }
}