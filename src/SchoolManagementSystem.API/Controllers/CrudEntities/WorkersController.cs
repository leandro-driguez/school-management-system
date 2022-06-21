
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkersController : Controller
{
    private readonly IWorkerService _service;

    public WorkersController(IWorkerService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetWorkers()
    {
        return Ok(_service.Query().ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetWorker(string id)
    {
        var worker = _service.GetWorkerById(id);
        if (worker == null)
        {
            return NotFound();
        }
        return Ok(worker);
    }
}
