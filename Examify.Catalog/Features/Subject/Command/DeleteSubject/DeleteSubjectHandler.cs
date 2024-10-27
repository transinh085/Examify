using Examify.Catalog.Infrastructure.Data;
using MediatR;

namespace Examify.Catalog.Features.Subject.Command.DeleteSubject;

public class DeleteSubjectHandler(CatalogContext context) : IRequestHandler<DeleteSubjectCommand, IResult>
{
    public async Task<IResult> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
    {
        var subject = await context.Subjects.FindAsync(request.Id, cancellationToken);
        if (subject == null)
        {
            return TypedResults.NotFound();
        }

        context.Subjects.Remove(subject);
        await context.SaveChangesAsync(cancellationToken);

        return TypedResults.NoContent();
    }
}