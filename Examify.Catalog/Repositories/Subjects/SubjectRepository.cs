using Examify.Catalog.Infrastructure.Data;
using Examify.Core.Pagination;

namespace Examify.Catalog.Repositories.Subjects;

public class SubjectRepository(CatalogContext catalogContext):ISubjectRepository
{
    public async Task<Entities.Subject> Create(Entities.Subject subject)
    {
        catalogContext.Subjects.Add(subject);
        await catalogContext.SaveChangesAsync();
        return subject;
    }
    
    public async Task<PagedList<Entities.Subject>> GetAll(int pageNumber, int pageSize)
    {
        return await catalogContext.Subjects.PaginatedListAsync(
            pageNumber: pageNumber,
            pageSize: pageSize
        );
    }
    
    public async Task<Entities.Subject?> FindById(Guid id)
    {
        return await catalogContext.Subjects.FindAsync(id);
    }
    
    public async Task<Entities.Subject> Update(Entities.Subject subject)
    {
        catalogContext.Subjects.Update(subject);
        await catalogContext.SaveChangesAsync();
        return subject;
    }
    
    public async Task<bool> Delete(Entities.Subject subject)
    {
        catalogContext.Subjects.Remove(subject);
        await catalogContext.SaveChangesAsync();
        return true;
    }
}