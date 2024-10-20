using Examify.Catalog.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Catalog.Features.Subject.GetAllSubject;

public class GetAllSubjectHandler(CatalogContext context) : IRequestHandler<GetAllSubjectQuery, List<Entities.Subject>>
{
    public async Task<List<Entities.Subject>> Handle(GetAllSubjectQuery request, CancellationToken cancellationToken)
    {
        return await context.Subjects.ToListAsync(cancellationToken);
    }
}