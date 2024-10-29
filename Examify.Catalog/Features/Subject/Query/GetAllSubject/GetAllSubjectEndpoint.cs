using Examify.Core.Endpoints;
using Examify.Core.Pagination;
using MediatR;

namespace Examify.Catalog.Features.Subject.Query.GetAllSubject;

public class GetAllSubjectEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/subjects", ([AsParameters] GetAllSubjectQuery query, ISender sender) => sender.Send(query))
            .Produces<PagedList<Entities.Subject>>()
            .WithTags("Subjects");
    }
}