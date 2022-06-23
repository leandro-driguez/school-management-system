
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
        if( worker == null)
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
            
        foreach(var info in dto.InfoByDate)
        {
            var _query = _service.GetWorkerFixSalaries(id);
            foreach (var row in _query)
            {
                info.InfoByPosition.Add(
                    new InfoByPositionDto{
                        Position = row.Position.Name,
                        PositionId = row.PositionId,
                        FixSalaryPosition = row.Payment
                    }
                );
            }
        }
        foreach(var info in dto.InfoByDate)
        {
            var _query = _service.GetWorkerCoursePorcentualSalaries(id);
            foreach (var row in _query)
            {
                var course = new InfoByCourseDto{
                        CourseId = row.CourseId,
                        CourseName = row.Course.Name,
                        Porcentage = row.PaidPorcentage,
                        InfoByCourseGroup = new List<InfoByCourseGroupDto>()
                    };
                
                    foreach (var cgroup in row.Course.CourseGroups)
                    {
                        course.InfoByCourseGroup.Add(
                            new InfoByCourseGroupDto{
                                CourseGroupId = cgroup.Id,
                                CourseGroupIncome = cgroup.StudentCourseGroupRelations.Count() * row.Course.Price,
                                CourseGroupWorkerPayment = row.PaidPorcentage * (cgroup.StudentCourseGroupRelations.Count() * row.Course.Price)
                            }
                        );
                    }
            }
        }
        return Ok(dto);
    }
}
