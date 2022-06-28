
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
public class WorkerPaymentGetFixSalary : Controller
{
    IDoWorkersPaymentService _service;
    IMapper mapper;
    public WorkerPaymentGetFixSalary(IDoWorkersPaymentService service, IMapper mapper)
    {
        this.mapper = mapper;
        _service = service;
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var worker = _service.Query().SingleOrDefault(c => c.Id == id);
        if (worker == null)
            NotFound();

        return Ok(_service.GetWorkerPaymentInfo(id).InfoByDate[0].InfoByPosition.Select(mapper.Map<InfoByPositionDto>));
    }

}
