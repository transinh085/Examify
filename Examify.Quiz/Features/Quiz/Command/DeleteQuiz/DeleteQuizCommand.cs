using Examify.Quiz.Infrastructure.Data;
using Examify.Quiz.Repositories.Quiz;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Quiz.Command.DeleteQuiz;

public record DeleteQuizCommand(Guid QuizId) : IRequest<IResult>;

public class DeleteQuizValidator : AbstractValidator<DeleteQuizCommand>
{
    public DeleteQuizValidator(IQuizRepository _quizRepository)
    {
        RuleFor(x => x.QuizId)
            .NotEmpty().WithMessage("Id is required")
            .MustAsync((id, cancellationToken) =>
                _quizRepository.IsQuizExists(id, cancellationToken)
            ).WithMessage("Quiz with this id does not exist");
    }
}