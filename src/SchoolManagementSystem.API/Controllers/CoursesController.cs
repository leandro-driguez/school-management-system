
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : Controller
{
    private readonly ICourseService _service;

    public CoursesController(ICourseService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetCourses()
    {
        return Ok(_service.Query().ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetCourse(string id)
    {
        var course = _service.GetCourseById(id);
        if (course == null)
        {
            return NotFound();
        }
        return Ok(course);
    }
}
