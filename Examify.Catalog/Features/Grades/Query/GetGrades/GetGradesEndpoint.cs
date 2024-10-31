using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Catalog.Features.Grades.Query.GetGrades;

public class GetGradesEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/grades", (ISender sender) => sender.Send(new GetGradesQuery()))
            .Produces<List<Entities.Grade>>()
            .WithTags("Grades");
    }
}