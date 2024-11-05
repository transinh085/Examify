using Examify.Catalog.Infrastructure.Data;
using Examify.Core.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Catalog.Features.Subject.Query.GetAllSubject;

public class GetAllSubjectHandler(CatalogContext context) : IRequestHandler<GetAllSubjectQuery, IResult>
{
    public async Task<IResult> Handle(GetAllSubjectQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Entities.Subject> query = context.Subjects;

        var subjects = await context.Subjects.ToListAsync();

        return TypedResults.Ok(subjects);
    }
}