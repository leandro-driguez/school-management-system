
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
    public DoWorkersPaymentController(IDoWorkersPaymentService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var worker = _service.Query().SingleOrDefault(c => c.Id == id);
        if (worker == null)
            NotFound();

        var dto = new ConsultWorkerSalaryGetSingleDto
        {
            Id = id,
            WorkerName = worker.Name,
            InfoByDate = new List<InfoByDateDto>(){new InfoByDateDto{
                    InfoByPosition = new List<InfoByPositionDto>(),
                    InfoByCourse = new List<InfoByCourseDto>()
                }},
        };

        var wPR_repo = _service.GetWorkerPositionRelationRepo();
        var _query = from wPR in wPR_repo.Query().Include(c => c.Position).Where(c => c.WorkerId == id)
                     select new { wPR.PositionId, salary = wPR.FixedSalary, Name = wPR.Position.Name };

        foreach (var row in _query)
        {
            dto.InfoByDate[0].InfoByPosition.Add(
                new InfoByPositionDto
                {
                    Position = row.Name,
                    PositionId = row.PositionId,
                    FixSalaryPosition = row.salary
                }
            );
        }
        var tCGR_repo = _service.GetTeacherCourseGroupRelationRepo();
        var tCR_repo = _service.GetTeacherCourseRelationRepo();
        foreach (var info in dto.InfoByDate)
        {
            var _querytcr = tCR_repo.Query().Where(c => c.TeacherId == id).Include(c => c.Course);
            foreach (var row in _querytcr)
            {
                InfoByCourseDto course = new InfoByCourseDto()
                {
                    CourseId = row.CourseId,
                    CourseName = row.Course.Name,
                    Porcentage = row.CorrespondingPorcentage,
                    InfoByCourseGroup = new List<InfoByCourseGroupDto>()
                };
                var _querytcgr = tCGR_repo.Query().Where(c => c.TeacherId == id 
                                                            && c.CourseGroupCourseId == course.CourseId)
                                                    .Include(c => c.CourseGroup.StudentCourseGroupRelations);
                foreach (var group in _querytcgr)
                {
                    var income = group.CourseGroup.StudentCourseGroupRelations.Count() * row.Course.Price;
                    course.InfoByCourseGroup.Add(new InfoByCourseGroupDto()
                    {
                        CourseGroupId = group.CourseGroup.Id
                        ,
                        CourseGroupName = group.CourseGroup.Name
                        ,
                        CourseGroupIncome = income
                        ,
                        CourseGroupWorkerPayment = ((double)(1.0) / 100) * income * course.Porcentage
                    });
                }
                dto.InfoByDate[0].InfoByCourse.Add(course);
            }

        }
        return Ok(dto);
    }

    [HttpPost]
    public IActionResult Post(DoWorkerPaymentDto dto)
    {
        _service.DoCoursePayment(dto.Date, dto.Id);
        _service.DoPositionPayment(dto.Date, dto.Id);
        return Ok();
    }
}
