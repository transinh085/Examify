using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Catalog.Features.Subject.CreateSubject;

public class CreateSubjectEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/subjects", (ISender sender, CreateSubjectCommand command) => sender.Send(command))
            .Produces<Entities.Subject>()
            .WithTags("Subjects");
    }
}