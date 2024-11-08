using Examify.Quiz.Infrastructure.Data;
using Examify.Quiz.Repositories.Questions;
using Examify.Quiz.Repositories.Quiz;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Questions.Query.GetQuestionsByQuizId;

public record GetQuesionsByQuizIdQuery(Guid Id) : IRequest<IResult>;

public class GetQuesionsByIdValidator : AbstractValidator<GetQuesionsByQuizIdQuery>
{
    public GetQuesionsByIdValidator(IQuizRepository quizRepository)
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .MustAsync(async (id, cancellationToken) =>
            {
                return await quizRepository.IsQuizExists(id, cancellationToken);
            }).WithMessage("Quiz not found");
    }
}