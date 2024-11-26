using Catalog;
using Examify.Catalog.Repositories.Subjects;
using Grpc.Core;

namespace Examify.Catalog.Grpc
{
    public class SubjectService(ISubjectRepository subjectRepository) : Subject.SubjectBase
    {
        public override async Task<SubjectReply> GetSubject(SubjectRequest request, ServerCallContext context)
        {
            var subject = await subjectRepository.FindById(Guid.Parse(request.Id), context.CancellationToken);

            if (subject is null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Subject not found"));
            }

            return new SubjectReply
            {
                Id = subject?.Id.ToString() ?? string.Empty,
                Name = subject?.Name ?? string.Empty,
            };
        }
    }
}