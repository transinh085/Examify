using Catalog;
using Examify.Catalog.Repositories.Language;
using Examify.Catalog.Repositories.Subjects;
using Grpc.Core;

namespace Examify.Catalog.Grpc
{
    public class SubjectService(ISubjectRepository subjectRepository) : Subject.SubjectBase
    {
        public override async Task<SubjectReply> GetSubject(SubjectRequest request, ServerCallContext context)
        {
            var subject = await subjectRepository.FindById(new Guid(request.Id), context.CancellationToken);
            return new SubjectReply
            {
                Id = subject?.Id.ToString() ?? string.Empty,
                Name = subject?.Name ?? string.Empty,
            };
        }
    }
}