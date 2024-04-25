using EntityFrameworkCodeFirst.Models.ViewModels;
using EntityFrameworkCodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCodeFirst.Controllers;

public class CoursesController(CourseService service) : Controller
{
    
    // GET
    public IActionResult Index()
    {
        var course = service.GetAllCourses();
        
        return View(course);
    }

    public IActionResult Edit(int id)
    {
        var courseToEdit = service.GetCourseById(id);

        if (courseToEdit == null) return RedirectToAction("Index");

        return View(courseToEdit);
    }
    
    public IActionResult Details(int id)
    {
        if (!ModelState.IsValid) return RedirectToAction("Index");
        
        var course = service.GetCourseDetailsById(id);

        return View(course);
    }
    
    // POST
    [HttpPost]
    public IActionResult Edit(EditCourseViewModel course)
    {
        if (!ModelState.IsValid) return View(course);
        
        service.UpdateCourse(course);
            
        return RedirectToAction("Index");
    }
}