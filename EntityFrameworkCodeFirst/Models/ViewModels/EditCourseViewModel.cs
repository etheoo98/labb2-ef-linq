using EntityFrameworkCodeFirst.Models.DatabaseModels;

namespace EntityFrameworkCodeFirst.Models.ViewModels;

public class EditCourseViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Teacher? CurrentTeacher { get; set; }
    public int NewTeacherId { get; set; }
    public List<Teacher>? Teachers { get; set; }
}