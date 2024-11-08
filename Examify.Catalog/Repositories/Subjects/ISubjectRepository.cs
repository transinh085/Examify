using Examify.Core.Pagination;

namespace Examify.Catalog.Repositories.Subjects;

public interface ISubjectRepository
{
    Task<Entities.Subject> Create(Entities.Subject subject);
    Task<PagedList<Entities.Subject>> GetAll(int pageNumber, int pageSize);
    
    Task<Entities.Subject?> FindById(Guid id, CancellationToken cancellationToken);
    
    Task<Entities.Subject> Update(Entities.Subject subject);

    Task Delete(Entities.Subject subject);
    Task<bool> IsSubjectExists(Guid id);
}