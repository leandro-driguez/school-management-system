
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkersController : Controller
{
    private readonly IService<Worker> _service;

    public WorkersController(IService<Worker> service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetWorkers()
    {
        return Ok(_service.Query().ToList());
    }
}
