using Examify.Core.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Examify.Quiz.Features.Quiz.Command.DeleteQuiz;

public class DeleteQuizEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/quizzes/{id}", async (ISender sender, Guid id) => sender.Send(new DeleteQuizCommand(id)))
            .Produces<NoContent>();
    }
}