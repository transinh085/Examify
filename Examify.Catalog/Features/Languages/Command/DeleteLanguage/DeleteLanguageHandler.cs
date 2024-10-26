using Ardalis.GuardClauses;
using Examify.Catalog.Repositories.Language;
using MediatR;

namespace Examify.Catalog.Features.Languages.DeleteLanguage;

public class DeleteLanguageHandler(ILanguageRepository languageRepository) : IRequestHandler<DeleteLanguageCommand, IResult>
{
    public async Task<IResult> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
    {
        var language = await languageRepository.FindLanguageByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, language);
        await languageRepository.DeleteLanguageAsync(language);
        return Results.NoContent();
    }
}