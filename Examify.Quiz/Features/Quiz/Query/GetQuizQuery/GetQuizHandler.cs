using AutoMapper;
using Examify.Quiz.Dtos;
using Examify.Quiz.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Quiz.Query.GetQuizQuery;

public class GetQuizHandler(QuizContext context) : IRequestHandler<GetQuizQuery, IResult>
{
    public async Task<IResult> Handle(GetQuizQuery request, CancellationToken cancellationToken)
    {
        var quiz = await context.Quizzes
            .FindAsync(request.Id, cancellationToken);

        return TypedResults.Ok(quiz);
    }
}