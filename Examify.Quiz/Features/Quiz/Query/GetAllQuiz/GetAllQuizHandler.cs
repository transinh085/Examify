using Examify.Quiz.Infrastructure.Data;
using Examify.Quiz.Repositories.Quiz;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Quizs.Query.GetAllQuiz;

public class GetAllQuizHandler(IQuizRepository quizRepository) : IRequestHandler<GetAllQuizQuery, IResult>
{
    public async Task<IResult> Handle(GetAllQuizQuery request, CancellationToken cancellationToken)
    {
        var quizzes = await quizRepository.GetAllQuizzes(cancellationToken);
        return TypedResults.Ok(quizzes);
    }
}