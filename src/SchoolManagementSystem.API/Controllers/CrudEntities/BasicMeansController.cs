
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BasicMeansController : Controller
{
    private readonly IService<BasicMean> _service;

    public BasicMeansController(IService<BasicMean> service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetBasicMeans()
    {
        return Ok(_service.Query().ToList());
    }
}
