using Examify.Core.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Examify.Catalog.Features.Languages.DeleteLanguage;

public class DeleteLanguageEndpoint: IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/languages/{id}", (ISender sender, Guid id) => sender.Send(new DeleteLanguageCommand(id)))
            .Produces<NoContent>()
            .WithTags("Languages");
    }
}