using Examify.Catalog.Infrastructure.Data;
using Examify.Core.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Examify.Catalog.Repositories.Language;

public class LanguageRepository(CatalogContext catalogContext) : ILanguageRepository
{
    public async Task<Entities.Language> CreateLanguageAsync(Entities.Language language)
    {
        catalogContext.Languages.Add(language);
        await catalogContext.SaveChangesAsync();
        return language;
    }

    public async Task<PagedList<Entities.Language>> GetLanguagesAsync(int pageNumber, int pageSize)
    {
        return await catalogContext.Languages.PaginatedListAsync(
            pageNumber: pageNumber,
            pageSize: pageSize
        );
    }
    
    public async Task<Entities.Language> FindLanguageByIdAsync(Guid languageId)
    {
        return await catalogContext.Languages.FirstOrDefaultAsync(x => x.Id == languageId);
    }
    
    public async Task<bool> DeleteLanguageAsync(Entities.Language language)
    {
        catalogContext.Languages.Remove(language);
        await catalogContext.SaveChangesAsync();
        return true;
    }

    public async Task<Entities.Language> UpdateLanguageAsync(Entities.Language language)
    {
        catalogContext.Languages.Update(language);
        await catalogContext.SaveChangesAsync();
        return language;
    }
    
}