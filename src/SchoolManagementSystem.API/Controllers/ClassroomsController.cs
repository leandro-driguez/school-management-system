
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClassroomsController : Controller
{
    private readonly IService<Classroom> _service;

    public ClassroomsController(IService<Classroom> service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetTop10()
    {
        return Ok(_service.Query().ToList<Classroom>());
    }
}

// git commit -m "Add API and remove UI without errors"
