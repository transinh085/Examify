using Examify.Core.Pagination;

namespace Examify.Catalog.Repositories.Language;

public interface ILanguageRepository
{
    Task<Entities.Language> CreateLanguageAsync(Entities.Language language);
    
    Task<List<Entities.Language>> GetLanguagesAsync();
    
    Task<Entities.Language?> FindLanguageByIdAsync(Guid languageId);
    
    Task<bool> DeleteLanguageAsync(Entities.Language languageId);
    
    Task<Entities.Language> UpdateLanguageAsync(Entities.Language language);
    
    Task<bool> IsLanguageExists(Guid languageId, CancellationToken cancellationToken);
}