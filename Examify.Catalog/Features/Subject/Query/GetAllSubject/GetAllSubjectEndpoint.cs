using Examify.Core.Endpoints;
using Examify.Core.Pagination;
using MediatR;

namespace Examify.Catalog.Features.Subject.Query.GetAllSubject;

public class GetAllSubjectEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/subjects", (ISender sender) => sender.Send(new GetAllSubjectQuery()))
            .Produces<List<Entities.Subject>>()
            .WithTags("Subjects");
    }
}