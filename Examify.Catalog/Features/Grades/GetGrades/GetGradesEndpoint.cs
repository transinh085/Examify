using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Catalog.Features.Grades.GetGrades;

public class GetGradesEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/grades", ([AsParameters] GetGradesQuery query, ISender sender) => sender.Send(query))
            .Produces<Entities.Grade>()
            .WithTags("Grades");
    }
}