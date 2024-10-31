using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.UpdateQuiz;

public class UpdateQuizEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/quizzes/{id}",
                async (ISender sender, UpdateQuizCommand command, Guid id) => await sender.Send(command with { Id = id }))
            .Produces<Entities.Quiz>();
    }
}