using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCodeFirst.Models.DatabaseModels;

public class Grade
{
    [Key]
    public int Id { get; set; }
    
    [StringLength(50, MinimumLength = 1)]
    public string Name { get; set; }
    
    public virtual ICollection<Student> Students { get; set; }
    
    [ForeignKey("Teacher")]
    public int FkTeacherId { get; set; }
    public virtual Teacher Teacher { get; set; }
}