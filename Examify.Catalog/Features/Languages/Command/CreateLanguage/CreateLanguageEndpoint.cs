using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Catalog.Features.Languages.CreateLanguage;

public class CreateLanguageEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/languages", (ISender sender, CreateLanguageCommand command) => sender.Send(command))
            .Produces<Entities.Language>()
            .WithTags("Languages"); 
    }
}