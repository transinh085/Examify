using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Catalog.Features.Grades.Command.CreateGrade;

public class CreateGradeEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/grades", (ISender sender, CreateGradeCommand command) => sender.Send(command))
            .Produces<Entities.Grade>()
            .WithTags("Grades"); 
    }
}