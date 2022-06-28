
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
public class WorkerPaymentGetSalaryPerCourseController : Controller
{
    IDoWorkersPaymentService _service;
    IMapper mapper;
    public WorkerPaymentGetSalaryPerCourseController(IDoWorkersPaymentService service, IMapper mapper)
    {
        this.mapper = mapper;
        _service = service;
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        string[] ids = id.Split("$$");
        var workerid = ids[0];var courseid = ids[1];

        var worker = _service.Query().SingleOrDefault(c => c.Id == workerid);
        if (worker == null)
            NotFound();

        return Ok(_service.GetWorkerPaymentInfo(workerid).InfoByDate[0]
                    .InfoByCourse
                    .Single(c => c.CourseId == courseid)
                    .InfoByCourseGroup
                    .Select(mapper.Map<InfoByCourseGroupDto>));
    }

}
