using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Catalog.Features.Grades.GetGrade;

public class GetGradeEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/grades/{id}",async (Guid id, ISender sender) =>
            {
                var query = new GetGradeQuery(id);
                return await sender.Send(query);
            })
            .Produces<Entities.Grade>()
            .WithTags("Grades");
    }
}