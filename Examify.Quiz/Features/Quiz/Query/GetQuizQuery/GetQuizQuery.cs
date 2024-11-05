using Examify.Quiz.Infrastructure.Data;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Quiz.Query.GetQuizQuery;

public record GetQuizQuery(Guid Id) : IRequest<IResult>;

public class GetQuizValidator : AbstractValidator<GetQuizQuery>
{
    public GetQuizValidator(QuizContext context)
    {
        RuleFor(x => x.Id).NotEmpty()
            .WithMessage("Quiz Id is required.")
            .MustAsync(async (id, cancellation) =>
                await context.Quizzes.AnyAsync(q => q.Id == id, cancellation)
            ).WithMessage("Quiz not found.");
    }
}