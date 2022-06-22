
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services.Entities;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeachersController : Controller
{
    private readonly ITeacherService _service;

    public TeachersController(ITeacherService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetTeachers()
    {
        return Ok(_service.Query().ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetTeacher(string id)
    {
        var teacher = _service.GetTeacherById(id);
        if (teacher == null)
        {
            return NotFound();
        }
        return Ok(teacher);
    }
}
