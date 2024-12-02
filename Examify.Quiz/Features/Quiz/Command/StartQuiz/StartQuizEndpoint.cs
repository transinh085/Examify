using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.StartQuiz;

public class StartQuizEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch("/quizzes/{id}/start", async (ISender sender, Guid id) => await sender.Send(new StartQuizCommand(id)))
            .WithTags("Quiz")
            .RequireAuthorization();
    }
}