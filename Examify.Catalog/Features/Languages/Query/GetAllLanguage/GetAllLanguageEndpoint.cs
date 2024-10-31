using Examify.Core.Endpoints;
using Examify.Core.Pagination;
using MediatR;

namespace Examify.Catalog.Features.Languages.GetAllLanguage;

public class GetAllLanguageEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/languages", (ISender sender) => sender.Send(new GetAllLanguageQuery()))
            .Produces<List<Entities.Language>>()
            .WithTags("Languages");
    }
}