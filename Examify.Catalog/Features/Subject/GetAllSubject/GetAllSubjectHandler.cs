using Examify.Catalog.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Catalog.Features.Subject.GetAllSubject;

public class GetAllSubjectHandler(CatalogContext context) : IRequestHandler<GetAllSubjectQuery, IResult>
{
    public async Task<IResult> Handle(GetAllSubjectQuery request, CancellationToken cancellationToken)
    {
        var subjects = await context.Subjects.ToListAsync(cancellationToken);
        return TypedResults.Ok(subjects);
    }
}