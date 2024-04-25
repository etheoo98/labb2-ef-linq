using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCodeFirst.Models.DatabaseModels;

public class Teacher
{
    [Key]
    public int Id { get; set; }
    
    public virtual ICollection<Course> Courses { get; set; }
    
    [ForeignKey("Person")]
    public int FkPersonId { get; set; }
    public virtual Person Person { get; set; }
}