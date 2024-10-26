using System.Security.Claims;
using Examify.Core.Endpoints;
using Examify.Core.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Examify.Catalog.Features.Subject.GetAllSubject;

public class GetAllSubjectEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/subjects", ([AsParameters] GetAllSubjectQuery query, ISender sender) => sender.Send(query))
            .Produces<PagedList<Entities.Subject>>()
            .WithTags("Subjects");
    }
}