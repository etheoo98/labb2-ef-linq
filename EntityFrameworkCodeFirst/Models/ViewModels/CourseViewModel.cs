using EntityFrameworkCodeFirst.Models.DatabaseModels;

namespace EntityFrameworkCodeFirst.Models.ViewModels;

public class CourseViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Teacher Teacher { get; set; }
}