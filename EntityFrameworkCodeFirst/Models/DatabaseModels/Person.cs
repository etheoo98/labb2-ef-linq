using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EntityFrameworkCodeFirst.Models.DatabaseModels;

public class Person
{
    [Key]
    public int Id { get; set; }
    
    [StringLength(100, MinimumLength = 2)]
    public string FirstName { get; set; }
    
    [StringLength(100, MinimumLength = 2)]
    public string LastName { get; set; }
}