using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Result.Features.Query.GetUserJoinQuiz;

public class GetUserJoinQuizEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/quiz-results/{code}/join-quiz", async (ISender sender, string code) => await sender.Send(new GetUserJoinQuizQuery(code)))
            .WithTags("Quiz Results")
            .RequireAuthorization();
    }
}