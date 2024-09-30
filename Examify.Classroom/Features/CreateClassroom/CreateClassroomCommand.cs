using FluentValidation;
using MediatR;

namespace Examify.Classroom.Features.CreateClassroom;

public record CreateClassroomCommand(string Name, string Description) : IRequest<Entities.Classroom>;

public class CreateClassroomValidator : AbstractValidator<CreateClassroomCommand>
{
    public CreateClassroomValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}