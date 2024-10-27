using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Catalog.Features.Grades.CreateGrade;

public class CreateGradeEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/grades", (ISender sender, CreateGradeCommand command) => sender.Send(command))
            .Produces<Entities.Grade>()
            .WithTags("Grades"); 
    }
}