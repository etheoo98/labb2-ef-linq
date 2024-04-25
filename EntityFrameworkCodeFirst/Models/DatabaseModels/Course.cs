using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCodeFirst.Models.DatabaseModels;

public class Course
{
    [Key]
    public int Id { get; set; }
    
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; }
    
    public virtual ICollection<Enrollment> Enrollments { get; set; }
    
    [ForeignKey("Teacher")]
    public int FkTeacherId { get; set; }
    public virtual Teacher Teacher { get; set; }
}