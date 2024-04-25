using EntityFrameworkCodeFirst.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCodeFirst.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Person> People { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        AddSampleData(modelBuilder);
    }

    private void AddSampleData(ModelBuilder modelBuilder)
    {
        // People Sample Data
        var people = new List<Person>
        {
            new() { Id = 1, FirstName = "Johan", LastName = "Edlund" },
            new() { Id = 2, FirstName = "Heikki", LastName = "Wallenberg" },
            new() { Id = 3, FirstName = "Leo", LastName = "Andersson" },
            new() { Id = 4, FirstName = "Ellen", LastName = "Blixt" },
            new() { Id = 5, FirstName = "Bengt", LastName = "Östrand" },
            new() { Id = 6, FirstName = "Klara", LastName = "Vi" }
        };
        
        modelBuilder.Entity<Person>().HasData(people);
        
        // Teacher Sample Data
        var teachers = new List<Teacher>
        {
            new() { Id = 1, FkPersonId = 1 }, 
            new() { Id = 2, FkPersonId = 2 }
        };

        modelBuilder.Entity<Teacher>().HasData(teachers);
        
        // Grade Sample Data
        var grades = new List<Grade>
        {
            new() { Id = 1, Name = ".NET23", FkTeacherId = teachers[0].Id }
        };
        
        modelBuilder.Entity<Grade>().HasData(grades);
        
        // Student Sample Data
        var students = new List<Student>
        {
            new() { Id = 1, FkPersonId = 3, FkGradeId = 1 },
            new() { Id = 2, FkPersonId = 4, FkGradeId = 1 },
            new() { Id = 3, FkPersonId = 5, FkGradeId = 1 },
            new() { Id = 4, FkPersonId = 6, FkGradeId = 1 },
        };

        modelBuilder.Entity<Student>().HasData(students);
        
        // Course Sample Data
        var courses = new List<Course>
        {
            // Assign all students to the courses
            new() { Id = 1, Name = "Web applications in C# ASP.NET", FkTeacherId = 1},
            new() { Id = 2, Name = "Project management and agile methods", FkTeacherId = 2}
        };

        modelBuilder.Entity<Course>().HasData(courses);
        
        // Enrollment Sample Data
        var enrollments = new List<Enrollment>
        {
            new() { Id = 1, FkCourseId = 1, FkStudentId = 1 },
            new() { Id = 2, FkCourseId = 2, FkStudentId = 2 },
            new() { Id = 3, FkCourseId = 1, FkStudentId = 3 },
            new() { Id = 4, FkCourseId = 2, FkStudentId = 3 },
            new() { Id = 5, FkCourseId = 1, FkStudentId = 4 },
            new() { Id = 6, FkCourseId = 2, FkStudentId = 4 }
        };
        
        modelBuilder.Entity<Enrollment>().HasData(enrollments);
    }
}