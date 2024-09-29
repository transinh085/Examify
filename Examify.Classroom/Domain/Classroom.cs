using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Examify.Classroom.Domain;

public class Classroom
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}