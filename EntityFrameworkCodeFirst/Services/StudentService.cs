using EntityFrameworkCodeFirst.Data;
using EntityFrameworkCodeFirst.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCodeFirst.Services;

public class StudentService(ApplicationDbContext context)
{
    public List<StudentViewModel> GetAllStudents()
    {
        var students = context.Students
            .Include(s => s.Person)
            .Include(s => s.Enrollments)
            .ThenInclude(e => e.Course)
            .ThenInclude(c => c.Teacher)
            .ThenInclude(t => t.Person)
            .Select(s => new StudentViewModel
            {
                Student = s, 
                Teachers = s.Enrollments.Select(e => e.Course.Teacher).ToHashSet()
            })
            .ToList();

        return students;
    }
}