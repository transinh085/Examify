using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.PlayQuiz;

public class PlayQuizEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch("/quizzes/{id}/play", async (ISender sender, Guid id) => await sender.Send(new PlayQuizCommand(id)))
            .WithTags("Quiz")
            .RequireAuthorization();
    }
}