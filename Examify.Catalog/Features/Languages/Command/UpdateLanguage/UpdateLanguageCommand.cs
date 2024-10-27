using Examify.Catalog.Repositories.Language;
using FluentValidation;
using MediatR;

namespace Examify.Catalog.Features.Languages.UpdateLanguage;

public record UpdateLanguageCommand(Guid Id, string Name) : IRequest<IResult>;

public class UpdateLanguageValidateCommand : AbstractValidator<UpdateLanguageCommand>
{
    private readonly ILanguageRepository _languageRepository;

    public UpdateLanguageValidateCommand(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name is not allowed over 100 characters")
            .MinimumLength(2).WithMessage("Name is not allowed under 2 characters");
    }
}