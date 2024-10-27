using Examify.Catalog.Infrastructure.Data;
using MediatR;

namespace Examify.Catalog.Features.Subject.Command.CreateSubject;

public class CreateSubjectHandler(CatalogContext context) : IRequestHandler<CreateSubjectCommand, IResult>
{
    public async Task<IResult> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
    {
        var subject = new Entities.Subject()
        {
            Name = request.Name
        };
        await context.Subjects.AddAsync(subject, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return TypedResults.Ok(subject);
    }
}