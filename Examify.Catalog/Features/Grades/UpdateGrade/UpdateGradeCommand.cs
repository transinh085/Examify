using Examify.Catalog.Repositories.Grades;
using FluentValidation;
using MediatR;

namespace Examify.Catalog.Features.Grades.UpdateGrade;

public record UpdateGradeCommand(Guid Id, string Name) : IRequest<IResult>;

public class UpdateGradeValidator : AbstractValidator<UpdateGradeCommand>
{
    private readonly IGradeRepository _gradeRepository;
    public UpdateGradeValidator(IGradeRepository gradeRepository)
    {
        _gradeRepository = gradeRepository;
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters")
            .MinimumLength(2).WithMessage("Name can not be less than 2 characters");
    }
}
