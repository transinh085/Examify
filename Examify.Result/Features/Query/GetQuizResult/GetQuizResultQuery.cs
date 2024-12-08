using Examify.Result.Repositories.QuizResults;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Result.Features.Query.GetQuizResult;

public record GetQuizResultQuery(Guid Id) : IRequest<IResult>;

public class GetQuizValidator : AbstractValidator<GetQuizResultQuery>
{
    public GetQuizValidator(IQuizResultRepository quizResultRepository)
    {
        RuleFor(x => x.Id).NotEmpty()
            .WithMessage("Id is required.")
            .MustAsync(async (id, cancellation) =>
                await quizResultRepository.Exists(id)
            ).WithMessage("Result not found.");
    }
}