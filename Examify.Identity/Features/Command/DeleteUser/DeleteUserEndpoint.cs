using Examify.Core.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Examify.Identity.Features.Command.DeleteUser;

public class DeleteUserEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/users/{id}", (string id, ISender sender) =>
            {
                sender.Send(new DeleteUserCommand(id));
                return TypedResults.NoContent();
            })
            .Produces<NoContent>()
            .WithTags("Users");
    }
}