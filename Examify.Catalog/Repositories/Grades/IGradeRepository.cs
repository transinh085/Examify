using Examify.Core.Pagination;

namespace Examify.Catalog.Repositories.Grades;

public interface IGradeRepository
{
    Task<Entities.Grade> Create(Entities.Grade grade);
    Task<PagedList<Entities.Grade>> GetAll(int pageNumber, int pageSize);
    
    Task<Entities.Grade?> FindById(Guid id);
    
    Task<Entities.Grade> Update(Entities.Grade grade);

    Task<bool> Delete(Entities.Grade grade);
}