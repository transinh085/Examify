using Examify.Catalog.DTO.grades;
using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Catalog.Features.Grades.Command.UpdateGrade;

public class UpdateGradeEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/grades/{id}", async (Guid id, UpdateGradeDTO request, ISender sender) =>
            {
                var command = new UpdateGradeCommand(id, request.Name);
                return await sender.Send(command);
            })
            .Produces<Entities.Grade>()
            .WithTags("Grades");
    }
}