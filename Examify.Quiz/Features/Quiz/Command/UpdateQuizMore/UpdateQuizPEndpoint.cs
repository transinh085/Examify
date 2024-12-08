using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.UpdateQuizMore;

public class UpdateQuizPEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/quizzes/p/{id}",
                async (ISender sender, UpdateQuizPCommand command, Guid id) => await sender.Send(command with { Id = id }))
            .Produces<Entities.Quiz>()
            .WithTags("Quiz")
            .RequireAuthorization();
    }
}