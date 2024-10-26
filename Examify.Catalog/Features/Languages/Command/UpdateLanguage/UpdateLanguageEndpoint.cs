using Examify.Catalog.Features.Languages.UpdateLanguage;
using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Catalog.Features.Languages.UpdateLanguage;

class UpdateLanguageEndpoint: IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/languages/{id}", async (Guid id, UpdateLanguageRequest request, ISender sender) =>
            {
                var command = new UpdateLanguageCommand(id, request.Name);
                return await sender.Send(command);
            })
            .Produces<Entities.Language>()
            .WithTags("Languages");
    }
}

public class UpdateLanguageRequest
{
    public string Name { get; set; }
}