using Examify.Classroom.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Classroom.Features.GetClassrooms;

public class GetClassroomHandler
    : IRequestHandler<GetClassroomsQuery, List<Entities.Classroom>>
{
    
    private readonly ClassroomContext context;
    private readonly ILogger<GetClassroomHandler> logger;
    
    public GetClassroomHandler(ClassroomContext context, ILogger<GetClassroomHandler> logger)
    {
        this.context = context;
        this.logger = logger;
    }
    
    public async Task<List<Entities.Classroom>> Handle(GetClassroomsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all classrooms");
        var classroom = await context.Classrooms
            .ToListAsync(cancellationToken);
        logger.LogInformation("Got all classrooms");
        return classroom;
    }
}