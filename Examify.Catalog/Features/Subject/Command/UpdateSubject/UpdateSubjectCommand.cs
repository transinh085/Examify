using Examify.Catalog.Repositories.Subjects;
using FluentValidation;
using MediatR;

namespace Examify.Catalog.Features.Subject.Command.UpdateSubject;

public record UpdateSubjectCommand(Guid Id,String Name) : IRequest<IResult>;

public class UpdateSubjectValidator : AbstractValidator<UpdateSubjectCommand>
{
    private readonly ISubjectRepository _subjectRepository;
    public UpdateSubjectValidator(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name is not allowed over 100 characters")
            .MinimumLength(2).WithMessage("Name is not allowed under 2 characters");
    }
}