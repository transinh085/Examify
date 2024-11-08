using FluentValidation;
using MediatR;

namespace Examify.Catalog.Features.Subject.Command.DeleteSubject;

public record DeleteSubjectCommand(Guid Id) : IRequest<IResult>;

public class DeleteSubjectValidator : AbstractValidator<DeleteSubjectCommand>
{
    public DeleteSubjectValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}