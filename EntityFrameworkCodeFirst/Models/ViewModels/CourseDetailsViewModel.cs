using EntityFrameworkCodeFirst.Models.DatabaseModels;

namespace EntityFrameworkCodeFirst.Models.ViewModels;

public class CourseDetailsViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Teacher Teacher { get; set; }
    public List<Student> Students { get; set; }
}