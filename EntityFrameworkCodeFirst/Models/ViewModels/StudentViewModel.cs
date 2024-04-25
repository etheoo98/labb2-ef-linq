using EntityFrameworkCodeFirst.Models.DatabaseModels;

namespace EntityFrameworkCodeFirst.Models.ViewModels;

public class StudentViewModel
{
    public Student Student { get; set; }
    public HashSet<Teacher> Teachers { get; set; }
}