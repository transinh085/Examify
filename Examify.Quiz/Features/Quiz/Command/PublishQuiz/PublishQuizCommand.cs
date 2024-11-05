using Examify.Quiz.Infrastructure.Data;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Quiz.Command.PublishQuiz;

public record PublishQuizCommand(Guid QuizId) : IRequest<IResult>;

public class PublishQuizValidator : AbstractValidator<PublishQuizCommand>
{
    public PublishQuizValidator(QuizContext context)
    {
        RuleFor(x => x.QuizId).MustAsync(async (quizId, cancellationToken) =>
        {
            return await context.Quizzes.AnyAsync(x => x.Id == quizId, cancellationToken);
        }).WithMessage("Quiz not found");
    }
}