using Examify.Core.Pagination;

namespace Examify.Catalog.Repositories.Language;

public interface ILanguageRepository
{
    Task<Entities.Language> CreateLanguageAsync(Entities.Language language);
    
    Task<PagedList<Entities.Language>> GetLanguagesAsync(int pageNumber, int pageSize);
    
    Task<Entities.Language> FindLanguageByIdAsync(Guid languageId);
    
    Task<bool> DeleteLanguageAsync(Entities.Language languageId);
    
    Task<Entities.Language> UpdateLanguageAsync(Entities.Language language);
}