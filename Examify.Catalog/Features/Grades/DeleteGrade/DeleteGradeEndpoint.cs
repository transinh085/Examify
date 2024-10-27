using Examify.Core.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Examify.Catalog.Features.Grades.DeleteGrade;

public class DeleteGradeEndpoint: IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/grades/{id}", (ISender sender, Guid id) => sender.Send(new DeleteGradeCommand(id)))
            .Produces<NoContent>()
            .WithTags("Grades");
    }
}