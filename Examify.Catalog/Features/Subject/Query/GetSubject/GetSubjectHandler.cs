using Examify.Catalog.Infrastructure.Data;
using MediatR;

namespace Examify.Catalog.Features.Subject.Query.GetSubject;

public class GetSubjectHandler(CatalogContext context) : IRequestHandler<GetSubjectQuery, IResult>
{
    public async Task<IResult> Handle(GetSubjectQuery request, CancellationToken cancellationToken)
    {
        var subject = await context.Subjects.FindAsync(request.Id, cancellationToken);
        if (subject is null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(subject);
    }
}