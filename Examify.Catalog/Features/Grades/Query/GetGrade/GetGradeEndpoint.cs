using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Catalog.Features.Grades.Query.GetGrade;

public class GetGradeEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/grades/{id}",async (Guid id, ISender sender) =>
            {
                var query = new GetGradeQuery(id);
                return await sender.Send(query);
            })
            .Produces<Entities.Grade>()
            .WithTags("Grades");
    }
}