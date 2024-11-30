using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.EndQuiz;

public class EndQuizEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch("/quizzes/{id}/end", async (ISender sender, Guid id) => await sender.Send(new EndQuizCommand(id)))
            .WithTags("Quiz")
            .RequireAuthorization();
    }
}