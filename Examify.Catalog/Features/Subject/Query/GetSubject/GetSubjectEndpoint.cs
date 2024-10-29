using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Catalog.Features.Subject.Query.GetSubject;

public class GetSubjectEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/subjects/{id}", (ISender sender, int id) => sender.Send(new GetSubjectQuery(id)))
            .Produces<Entities.Subject>();
    }
}