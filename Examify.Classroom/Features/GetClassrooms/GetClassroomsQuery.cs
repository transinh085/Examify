using MediatR;

namespace Examify.Classroom.Features.GetClassrooms;

public class GetClassroomsQuery : IRequest<List<Entities.Classroom>>
{
    
}