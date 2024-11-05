using Examify.Core.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Examify.Quiz.Features.Quiz.Command.PublishQuiz;

public class PublishQuizEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch("quizzes/{quizId}/publish", async (Guid quizId, ISender sender) =>
            await sender.Send(new PublishQuizCommand(quizId))
        ).Produces<NoContent>()
        .WithTags("Quiz");
    }
}