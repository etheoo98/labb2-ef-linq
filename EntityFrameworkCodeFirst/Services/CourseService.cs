using EntityFrameworkCodeFirst.Data;
using EntityFrameworkCodeFirst.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCodeFirst.Services;

public class CourseService(ApplicationDbContext context)
{
    public List<CourseViewModel> GetAllCourses() => context.Courses
        .Select(c => new CourseViewModel{Id = c.Id, Name = c.Name}).ToList();

    public EditCourseViewModel? GetCourseById(int id)
    {
        var course = context.Courses
            .Where(c => c.Id == id)
            .Include(c => c.Teacher)
            .ThenInclude(t => t.Person)
            .FirstOrDefault();
        
        var teachers = context.Teachers
            .Include(t => t.Person)
            .ToList();
        
        return course == null 
            ? null 
            : new EditCourseViewModel
            {
                Id = course.Id, Name = course.Name, 
                CurrentTeacher = course.Teacher, 
                Teachers = teachers
            };
    }

    public CourseDetailsViewModel? GetCourseDetailsById(int id)
    {
        var courseDetails = context.Courses.Where(c => c.Id == id)
            .Include(c => c.Teacher)
            .ThenInclude(t => t.Person)
            .Include(c => c.Enrollments)
            .ThenInclude(e => e.Student)
            .ThenInclude(s => s.Person)
            .Select(c => new CourseDetailsViewModel
            {
                Id = c.Id, 
                Name = c.Name, 
                Teacher = c.Teacher, 
                Students = c.Enrollments.Select(e => e.Student).ToList()
            }).FirstOrDefault();

        return courseDetails ?? null;
    }

    public void UpdateCourse(EditCourseViewModel editCourseViewModel)
    {
        var course = context.Courses.FirstOrDefault(c => c.Id == editCourseViewModel.Id);
        
        if (course == null) return;
        
        course.Name = editCourseViewModel.Name;
        course.FkTeacherId = editCourseViewModel.NewTeacherId;
        
        context.SaveChanges();
    }
}