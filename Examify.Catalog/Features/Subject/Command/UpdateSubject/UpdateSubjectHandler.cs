using Ardalis.GuardClauses;
using Examify.Catalog.Repositories.Subjects;
using MediatR;

namespace Examify.Catalog.Features.Subject.Command.UpdateSubject;

public class UpdateSubjectHandler(ISubjectRepository subjectRepository) : IRequestHandler<UpdateSubjectCommand,IResult >
{
    public async Task<IResult> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
    {
        var existingSubject = await subjectRepository.FindById(request.Id);
        Guard.Against.NotFound(request.Id, existingSubject);
        existingSubject.Name = request.Name;
        var updatedSubject = await subjectRepository.Update(existingSubject);
        return Results.Ok(updatedSubject);
    }
}