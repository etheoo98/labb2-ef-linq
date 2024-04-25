using EntityFrameworkCodeFirst.Data;
using EntityFrameworkCodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCodeFirst.Controllers;

public class StudentsController(StudentService service) : Controller
{
    // GET
    public IActionResult Index()
    {
        var students = service.GetAllStudents();

        return View(students);
    }
}