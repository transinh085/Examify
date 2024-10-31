using System.ComponentModel.DataAnnotations.Schema;

namespace Examify.Core.Entitites;

public class BaseEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }   
}