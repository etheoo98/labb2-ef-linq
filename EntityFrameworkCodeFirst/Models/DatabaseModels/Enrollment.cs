using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCodeFirst.Models.DatabaseModels;

// Junction table
public class Enrollment
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey("Student")]
    public int FkStudentId { get; set; }
    public virtual Student Student { get; set; }
    
    [ForeignKey("Course")] 
    public int FkCourseId { get; set; }
    public virtual Course Course { get; set; }
}