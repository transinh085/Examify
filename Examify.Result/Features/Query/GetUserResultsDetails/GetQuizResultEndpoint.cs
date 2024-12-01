using Examify.Core.Endpoints;
using Examify.Quiz.Dtos;
using MediatR;

namespace Examify.Result.Features.Query.GetResultsOfQuiz;

public class GetResultsOfQuizEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/quiz/{quizId}/quiz-results", async (ISender sender, string quizId) => await sender.Send(new GetResultsOfQuizQuery(quizId)))
            .Produces<GetQuizResultsDto>()
            .WithTags("Quiz Results")
            .RequireAuthorization();
    }
}