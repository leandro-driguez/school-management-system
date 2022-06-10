using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.UI.Models;

namespace SchoolManagementSystem.UI.Controllers;

public class ClassroomsController : Controller
{
    private readonly SchoolContext _context;

    public ClassroomsController(SchoolContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Classrooms.ToList<Classroom>());
    }

    public IActionResult Create()
    {
        return View();
    } 

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
