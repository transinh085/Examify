using Catalog;
using Examify.Catalog.Repositories.Subjects;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace Examify.Catalog.Grpc
{
    public class SubjectService(ISubjectRepository subjectRepository) : Subject.SubjectBase
    {
        public override async Task<GetSubjectReponse> GetSubject(SubjectRequest request, ServerCallContext context)
        {
            var subject = await subjectRepository.FindById(Guid.Parse(request.Id), context.CancellationToken);

            if (subject is null)
            {
                return new GetSubjectReponse
                {
                    Empty = new Empty()
                };
            }
            return new GetSubjectReponse
            {
                Subject = new SubjectReply
                {
                    Id = subject.Id.ToString(),
                    Name = subject.Name,
                }
            };
        }
    }
}