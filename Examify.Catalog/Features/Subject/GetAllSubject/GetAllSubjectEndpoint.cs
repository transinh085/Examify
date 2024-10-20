using System.Security.Claims;
using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Catalog.Features.Subject.GetAllSubject;

public class GetAllSubjectEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/subjects", (ISender sender) => sender.Send(new GetAllSubjectQuery()));
    }
}