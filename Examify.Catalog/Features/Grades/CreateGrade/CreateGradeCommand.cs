using Examify.Catalog.Repositories.Grades;
using FluentValidation;
using MediatR;

namespace Examify.Catalog.Features.Grades.CreateGrade;
public record CreateGradeCommand(string Name) : IRequest<IResult>;

public class CreateGradeValidator : AbstractValidator<CreateGradeCommand>
{
    private readonly IGradeRepository _gradeRepository;
    public CreateGradeValidator(IGradeRepository gradeRepository)
    {
        _gradeRepository = gradeRepository;
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters")
            .MinimumLength(2).WithMessage("Name can not be less than 2 characters");
    }
}