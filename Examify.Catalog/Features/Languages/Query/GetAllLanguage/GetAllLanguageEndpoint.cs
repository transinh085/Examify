using Examify.Core.Endpoints;
using Examify.Core.Pagination;
using MediatR;

namespace Examify.Catalog.Features.Languages.GetAllLanguage;

public class GetAllLanguageEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/languages", ([AsParameters] GetAllLanguageQuery query, ISender sender) => sender.Send(query))
            .Produces<PagedList<Entities.Language>>()
            .WithTags("Languages");
    }
}