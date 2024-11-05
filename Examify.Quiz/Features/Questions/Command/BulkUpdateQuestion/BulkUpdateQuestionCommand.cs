using Examify.Quiz.Infrastructure.Data;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Questions.Command.BulkUpdateQuestion;

public record BulkUpdateQuestionCommand(Guid QuizId, int? Duration, int? Points) : IRequest<IResult>;

public class BulkUpdateValidator : AbstractValidator<BulkUpdateQuestionCommand>
{
    public BulkUpdateValidator(QuizContext context)
    {
        RuleFor(x => x.QuizId).MustAsync(async (quizId, cancellationToken) =>
        {
            return await context.Quizzes.AnyAsync(x => x.Id == quizId, cancellationToken);
        }).WithMessage("Quiz not found");
    }
}