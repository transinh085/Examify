using Examify.Quiz.Infrastructure.Data;
using Examify.Quiz.Repositories.Quiz;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Quiz.Query.GetQuizQuery;

public record GetQuizQuery(Guid Id) : IRequest<IResult>;

public class GetQuizValidator : AbstractValidator<GetQuizQuery>
{
    public GetQuizValidator(IQuizRepository quizRepository)
    {
        RuleFor(x => x.Id).NotEmpty()
            .WithMessage("Quiz Id is required.")
            .MustAsync(async (id, cancellation) =>
                await quizRepository.IsQuizExists(id, cancellation)
            ).WithMessage("Quiz not found.");
    }
}