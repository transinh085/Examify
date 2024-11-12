using Examify.Catalog.Infrastructure.Data;
using Examify.Catalog.Repositories.Subjects;
using MediatR;

namespace Examify.Catalog.Features.Subject.Command.DeleteSubject;

public class DeleteSubjectHandler(ISubjectRepository subjectRepository) : IRequestHandler<DeleteSubjectCommand, IResult>
{
    public async Task<IResult> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
    {
        var subject = await subjectRepository.FindById(request.Id, cancellationToken);
        await subjectRepository.Delete(subject);
        return TypedResults.NoContent();
    }
}