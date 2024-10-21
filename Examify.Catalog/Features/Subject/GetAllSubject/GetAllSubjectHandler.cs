using Examify.Catalog.Infrastructure.Data;
using Examify.Core.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Catalog.Features.Subject.GetAllSubject;

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