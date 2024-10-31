using Examify.Quiz.Infrastructure.Data;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Quiz.Command.DeleteQuiz;

public record DeleteQuizCommand(Guid Id) : IRequest<IResult>;

public class DeleteQuizValidator : AbstractValidator<DeleteQuizCommand>
{
    public DeleteQuizValidator(QuizContext context)
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .MustAsync((id, cancellationToken) =>
                context.Quizzes.AnyAsync(x => x.Id == id, cancellationToken)
            ).WithMessage("Quiz with this id does not exist");
    }
}