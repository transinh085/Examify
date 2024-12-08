using Examify.Result.Repositories.QuizResults;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Result.Features.Query.GetUsersResultsDetails;

public record GetUsersResultsDetailsQuery(string quizId, string userId) : IRequest<IResult>;

public class GetQuizValidator : AbstractValidator<GetUsersResultsDetailsQuery>
{
    public GetQuizValidator(IQuizResultRepository quizResultRepository)
    {
        RuleFor(x => x.quizId).NotEmpty()
            .WithMessage("quizId is required.");
        RuleFor(x => x.userId).NotEmpty()
            .WithMessage("userId is required.");
    }
}