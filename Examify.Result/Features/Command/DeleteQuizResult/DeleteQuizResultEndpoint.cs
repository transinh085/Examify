using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Result.Features.Command.DeleteQuizResult;

public class DeleteQuizResultEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("quiz-results/{id:guid}", async (ISender sender, Guid id) =>
            await sender.Send(new DeleteQuizResultCommand(id)
        )).RequireAuthorization();
    }
}
