using Examify.Result.Repositories.QuizResults;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Result.Features.Query.GetResultsOfQuiz;

public record GetResultsOfQuizQuery(string quizId) : IRequest<IResult>;

public class GetQuizValidator : AbstractValidator<GetResultsOfQuizQuery>
{
    public GetQuizValidator(IQuizResultRepository quizResultRepository)
    {
        RuleFor(x => x.quizId).NotEmpty()
            .WithMessage("quizId is required.");
    }
}