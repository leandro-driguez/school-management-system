
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
    public ConsultWorkerSalaryController(IConsultWorkerSalaryService service)
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
                InfoByDate = new List<InfoByDateDto>(),
            };
            
        foreach(var date in _service.GetAllPaymentDates(id))
            dto.InfoByDate.Add(
                    new InfoByDateDto{
                        Date = date,
                        InfoByPosition =  new List<InfoByPositionDto>(),
                        InfoByCourse = new List<InfoByCourseDto>()
                    });

        foreach(var info in dto.InfoByDate)
        {
            var _query = _service.GetWorkerFixSalariesByDate(id,info.Date);
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
        var tCGR_repo = _service.GetTeacherCourseGroupRelationRepo();
        var tCR_repo = _service.GetTeacherCourseRelationRepo();
        foreach(var info in dto.InfoByDate)
        {
            var courserow = from tcgr in tCGR_repo.Query().Where(c => c.TeacherId == id 
                                                                && c.StartDate <= info.Date
                                                                && (c.EndDate >= info.Date || c.EndDate < c.StartDate))
                    join tcr in tCR_repo.Query().Where(c => c.TeacherId == id)
                        on new {CourseId = tcgr.CourseGroupCourseId, tcgr.TeacherId}
                        equals new {CourseId = tcr.CourseId, tcr.TeacherId}
                    into details
                    from d in details
                    select new {
                        CourseId = d.CourseId,
                        CourseName = d.Course.Name,
                        CourseGroupId = d.Course,
                        Porcentage = d.CorrespondingPorcentage,
                  };
            foreach (var row in courserow )
            {
                InfoByCourseDto course = new InfoByCourseDto(){
                    CourseId = row.CourseId,
                    CourseName = row.CourseName,
                    Porcentage = row.Porcentage,
                    InfoByCourseGroup = new List<InfoByCourseGroupDto>()
                };
                var groups = (from tCGR in tCGR_repo.Query().Include(c => c.CourseGroup.StudentCourseGroupRelations).Where(c => c.TeacherId == id)
                            join tCR in tCR_repo.Query().Include(c => c.Course).Where(c => c.TeacherId == id)
                            on tCGR.CourseGroupCourseId equals tCR.CourseId
                        where tCGR.CourseGroupCourseId == row.CourseId
                        select new { tCGR.CourseGroup, StudentAmount = tCGR.CourseGroup.StudentCourseGroupRelations.Count(), tCR.Course.Price});
                foreach (var group in groups)
                {
                    course.InfoByCourseGroup.Add(new InfoByCourseGroupDto(){
                        CourseGroupId = group.CourseGroup.Id
                        ,CourseGroupName = group.CourseGroup.Name
                        , CourseGroupIncome = group.StudentAmount * group.Price
                        ,CourseGroupWorkerPayment = ((double)(1.0)/100) * course.Porcentage * group.StudentAmount * group.Price
                    });
                }
                dto.InfoByDate[0].InfoByCourse.Add(course);
            }
            
        }
        return Ok(dto);
    }
}
