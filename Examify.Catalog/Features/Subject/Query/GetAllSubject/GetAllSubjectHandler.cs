using Examify.Catalog.Infrastructure.Data;
using Examify.Core.Pagination;
using MediatR;

namespace Examify.Catalog.Features.Subject.Query.GetAllSubject;

public class GetAllSubjectHandler(CatalogContext context) : IRequestHandler<GetAllSubjectQuery, IResult>
{
    public async Task<IResult> Handle(GetAllSubjectQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Entities.Subject> query = context.Subjects;

        var subjects = await query.PaginatedListAsync(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize
        );

        return TypedResults.Ok(subjects);
    }
}