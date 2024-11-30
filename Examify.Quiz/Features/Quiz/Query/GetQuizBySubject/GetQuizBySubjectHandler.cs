using Examify.Quiz.Infrastructure.Data;
using Examify.Quiz.Repositories.Quiz;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Quiz.Query.GetQuizBySubject;

public class GetQuizBySubjectHandler(IQuizRepository quizRepository) : IRequestHandler<GetQuizBySubjectQuery, IResult>
{
    public async Task<IResult> Handle(GetQuizBySubjectQuery request, CancellationToken cancellationToken)
    {
        var quizzes = await quizRepository.GetQuizzesBySubject(request.SubjectId, request.PageNumber, request.PageSize,
            cancellationToken);
        return TypedResults.Ok(quizzes);
    }
}