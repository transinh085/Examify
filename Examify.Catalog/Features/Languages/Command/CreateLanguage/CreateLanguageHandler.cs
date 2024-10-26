using Examify.Catalog.Infrastructure.Data;
using Examify.Catalog.Repositories.Language;
using MediatR;

namespace Examify.Catalog.Features.Languages.CreateLanguage;

public class CreateLanguageHandler(ILanguageRepository languageRepository) : IRequestHandler<CreateLanguageCommand, IResult>
{
    public async  Task<IResult> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
    {
        var language = new Entities.Language()
        {
            Name = request.Name
        };
        await languageRepository.CreateLanguageAsync(language);
        return TypedResults.Ok(language);
    }
}