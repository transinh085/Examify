using Examify.Catalog.DTO.subjects;
using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Catalog.Features.Subject.Command.UpdateSubject;

public class UpdateSubjectEndpoint :IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/subjects/{id}", async (Guid id, UpdateSubjectDTO request, ISender sender) =>
            {
                var command = new UpdateSubjectCommand(id, request.Name);
                return await sender.Send(command);
            })
            .Produces<Entities.Subject>()
            .WithTags("Subjects");
    }
}