
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
        
        var wPR_repo = _service.GetWorkerPositionRelationRepo();
        var _query =  from wPR in wPR_repo.Query().Include(c => c.Position).Where(c => c.WorkerId == id)
                     select new {wPR.PositionId, salary = wPR.FixedSalary, Name = wPR.Position.Name};

        foreach (var row in _query)
        {
            dto.InfoByDate[0].InfoByPosition.Add(
                new InfoByPositionDto{
                    Position = row.Name,
                    PositionId = row.PositionId,
                    FixSalaryPosition = row.salary
                }
            );
        }
        var tCGR_repo = _service.GetTeacherCourseGroupRelationRepo();
        var tCR_repo = _service.GetTeacherCourseRelationRepo();
        foreach(var info in dto.InfoByDate)
        {
            var courserow = from tcgr in tCGR_repo.Query().Where(c => c.TeacherId == id)
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
