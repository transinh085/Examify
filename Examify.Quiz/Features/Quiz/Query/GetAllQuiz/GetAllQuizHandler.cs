using Examify.Quiz.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Quizs.Query.GetAllQuiz;

public class GetAllQuizHandler(QuizContext context) : IRequestHandler<GetAllQuizQuery, IResult>
{
    public async Task<IResult> Handle(GetAllQuizQuery request, CancellationToken cancellationToken)
    {
        var quizzes = await context.Quizzes.AsNoTracking().ToListAsync(cancellationToken);
        return TypedResults.Ok(quizzes);
    }
}