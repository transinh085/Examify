using Examify.Catalog.Infrastructure.Data;
using Examify.Core.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Examify.Catalog.Repositories.Grades;

public class GradeRepository(CatalogContext catalogContext) : IGradeRepository
{
    public async Task<Entities.Grade> Create(Entities.Grade grade)
    {
        catalogContext.Grades.Add(grade);
        await catalogContext.SaveChangesAsync();
        return grade;
    }
    
    public async Task<List<Entities.Grade>> GetAll()
    {
        return await catalogContext.Grades.ToListAsync();
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