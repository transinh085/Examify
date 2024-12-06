using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Result.Features.Query.GetStartQuiz;

public class GetStartQuizEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/quiz-results/{code}/start-quiz", async (ISender sender, string code) => await sender.Send(new GetStartQuizQuery(code)))
            .WithTags("Quiz Results")
            .RequireAuthorization();
    }
}