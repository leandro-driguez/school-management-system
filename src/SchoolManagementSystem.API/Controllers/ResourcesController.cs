
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResourcesController : Controller
{
    private readonly IResourceService _service;

    public ResourcesController(IResourceService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetResources()
    {
        return Ok(_service.Query().ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetResource(string id)
    {
        var resource = _service.GetResourceById(id);
        if (resource == null)
        {
            return NotFound();
        }
        return Ok(resource);
    }
}
