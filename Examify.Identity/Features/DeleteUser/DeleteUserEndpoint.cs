using Ardalis.Result;
using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Identity.Features.DeleteUser;

public class DeleteUserEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/users/{id}", (string id, ISender sender) =>
        {
            sender.Send(new DeleteUserCommand(id));
            return TypedResults.NoContent();
        }).WithTags("Users");
    }
}