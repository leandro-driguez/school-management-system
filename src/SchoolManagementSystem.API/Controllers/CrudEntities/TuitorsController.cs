
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services.Entities;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TuitorsController : Controller
{
    private readonly ITuitorService _service;

    public TuitorsController(ITuitorService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetTuitors()
    {
        return Ok(_service.Query().ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetTuitor(string id)
    {
        var tuitor = _service.GetTuitorById(id);
        if (tuitor == null)
        {
            return NotFound();
        }
        return Ok(tuitor);
    }
}
