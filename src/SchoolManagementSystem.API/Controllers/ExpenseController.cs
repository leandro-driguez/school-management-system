
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController : Controller
{
    private readonly IService<Expense> _service;

    public ExpensesController(IService<Expense> service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetExpenses()
    {
        return Ok(_service.Query().ToList());
    }
}
