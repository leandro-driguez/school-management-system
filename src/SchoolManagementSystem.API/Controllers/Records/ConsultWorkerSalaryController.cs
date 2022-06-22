
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Application.Services_Implementations;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using Microsoft.EntityFrameworkCore; 
using AutoMapper;

namespace SchoolManagementSystem.API.Controllers.Records;

[Route("api/[controller]")]
public class ConsultWorkerSalaryController : Controller
{   
    IConsultWorkerSalaryService _service;
    public ConsultWorkerSalaryController(IConsultWorkerSalaryService service)//, 
        /*IMapper mapper*/ 
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var worker = _service.Query().SingleOrDefault(c => c.Id == id);
        if( worker == null)
            NotFound();

        var dto = new ConsultWorkerSalaryGetSingleDto
            {
                Id = id,
                WorkerName = worker.Name,
                TotalFixSalary = _service.GetTotalWorkerFixSalaries(id),
                TotalCoursesPorcentualPayment = _service.GetTotalWorkerCoursePorcentualSalaries(id)
            };
        return Ok(dto);
    }
}
