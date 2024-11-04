using Examify.Quiz.Infrastructure.Data;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Questions.Query.GetQuestionsByQuizId;

public record GetQuesionsByQuizIdQuery(Guid Id) : IRequest<IResult>;

public class GetQuesionsByIdValidator : AbstractValidator<GetQuesionsByQuizIdQuery>
{
    public GetQuesionsByIdValidator(QuizContext context)
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .MustAsync(async (id, cancellationToken) =>
            {
                return await context.Quizzes.AnyAsync(x => x.Id == id, cancellationToken);
            }).WithMessage("Quiz not found");
    }
}