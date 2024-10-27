using Examify.Catalog.Infrastructure.Data;
using Examify.Core.Pagination;

namespace Examify.Catalog.Repositories.Grades;

public class GradeRepository(CatalogContext catalogContext) : IGradeRepository
{
    public async Task<Entities.Grade> Create(Entities.Grade grade)
    {
        catalogContext.Grades.Add(grade);
        await catalogContext.SaveChangesAsync();
        return grade;
    }
    
    public async Task<PagedList<Entities.Grade>> GetAll(int pageNumber, int pageSize)
    {
        return await catalogContext.Grades.PaginatedListAsync(
            pageNumber: pageNumber,
            pageSize: pageSize
        );
    }
    
    public async Task<Entities.Grade?> FindById(Guid id)
    {
        return await catalogContext.Grades.FindAsync(id);
    }
    
    public async Task<Entities.Grade> Update(Entities.Grade grade)
    {
        catalogContext.Grades.Update(grade);
        await catalogContext.SaveChangesAsync();
        return grade;
    }
    
    public async Task<bool> Delete(Entities.Grade grade)
    {
        catalogContext.Grades.Remove(grade);
        await catalogContext.SaveChangesAsync();
        return true;
    }

}