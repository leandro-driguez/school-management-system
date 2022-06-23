
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
        var tCGR_repo = _service.GetTeacherCourseGroupRelationRepo(id);
        var tCR_repo = _service.GetTeacherCourseRelationRepo(id);
        var sCGR_repo = _service.GetTeacherCourseRelationRepo(id);
        // var public IRepository<StudentCourseGroupRelation> GetStudentCourseGroupRelationRepo(string id);
        foreach(var info in dto.InfoByDate)
        {
            var courserow = from tcgr in tCGR_repo.Query()
                    join tcr in tCR_repo.Query()
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
                var groups = (from tCGR in tCGR_repo.Query().Include(c => c.CourseGroup)
                        where tCGR.CourseGroupCourseId == row.CourseId
                        select new { tCGR.CourseGroup});
                foreach (var group in groups)
                {
                    course.InfoByCourseGroup.Add(new InfoByCourseGroupDto(){
                        CourseGroupId = group.CourseGroup.Id
                    });
                }
                dto.InfoByDate[0].InfoByCourse.Add(course);
                        // group tCGR2 by tCGR2.CourseGroupCourseId;
                        
            }
            
                    // foreach (var cgroup in row.Course.CourseGroups)
                    // {
                    //     course.InfoByCourseGroup.Add(
                    //         new InfoByCourseGroupDto{
                    //             CourseGroupId = cgroup.Id,
                    //             CourseGroupIncome = cgroup.StudentCourseGroupRelations.Count() * row.Course.Price,
                    //             CourseGroupWorkerPayment = row.PaidPorcentage * (cgroup.StudentCourseGroupRelations.Count() * row.Course.Price)
                    //         }
                    //     );
                    // }
        //     }
        }
        return Ok(dto);
    }
}
