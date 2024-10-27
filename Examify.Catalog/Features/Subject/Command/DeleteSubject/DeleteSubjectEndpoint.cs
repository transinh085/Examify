using Examify.Core.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Examify.Catalog.Features.Subject.Command.DeleteSubject;

public class DeleteSubjectEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/subjects/{id}", (ISender sender, int id) => sender.Send(new DeleteSubjectCommand(id)))
            .Produces<NoContent>();
    }
}