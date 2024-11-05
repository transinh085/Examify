using Examify.Core.Pagination;

namespace Examify.Catalog.Repositories.Subjects;

public interface ISubjectRepository
{
    Task<Entities.Subject> Create(Entities.Subject subject);
    Task<PagedList<Entities.Subject>> GetAll(int pageNumber, int pageSize);
    
    Task<Entities.Subject?> FindById(Guid id);
    
    Task<Entities.Subject> Update(Entities.Subject subject);

    Task<bool> Delete(Entities.Subject subject);
}