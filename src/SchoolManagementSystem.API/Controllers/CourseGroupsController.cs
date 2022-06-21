
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseGroupsController : Controller
{
    private readonly ICourseGroupService _service;

    public CourseGroupsController(ICourseGroupService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetCourseGroups()
    {
        return Ok(_service.Query().ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetCourseGroup(string id)
    {
        var courseGroup = _service.GetCourseGroupById(id);
        if (courseGroup == null)
        {
            return NotFound();
        }
        return Ok(courseGroup);
    }
}
