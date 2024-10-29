using Examify.Core.Pagination;
using MediatR;

namespace Examify.Catalog.Features.Languages.GetAllLanguage;

public record GetAllLanguageQuery : IRequest<IResult>, IPageRequest
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}