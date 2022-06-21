
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PositionsController : Controller
{
    private readonly IService<Position> _service;

    public PositionsController(IService<Position> service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetPositions()
    {
        return Ok(_service.Query().ToList());
    }
}
