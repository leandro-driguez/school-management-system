
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
public class DoWorkersPaymentController : Controller
{
    IDoWorkersPaymentService _service;
    IMapper mapper;
    public DoWorkersPaymentController(IDoWorkersPaymentService service, IMapper mapper)
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


        return Ok(mapper.Map<ConsultWorkerSalaryGetSingleDto>(_service.GetWorkerPaymentInfo(id)));
    }

    [HttpPost]
    public IActionResult Post(DoWorkerPaymentDto dto)
    {
        _service.DoCoursePayment(dto.Date, dto.Id);
        _service.DoPositionPayment(dto.Date, dto.Id);
        return Ok();
    }
}
