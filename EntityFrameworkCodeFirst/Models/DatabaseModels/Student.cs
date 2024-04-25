using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCodeFirst.Models.DatabaseModels;

public class Student
{
    [Key]
    public int Id { get; set; }
    
    public virtual ICollection<Enrollment> Enrollments { get; set; }
    
    // One-to-one relationship with Person
    [ForeignKey("Person")]
    public int FkPersonId { get; set; }
    public virtual Person Person { get; set; }
    
    // One-to-one relationship with Grade
    [ForeignKey("Grade")]
    public int FkGradeId { get; set; }
    public virtual Grade Grade { get; set; }
}