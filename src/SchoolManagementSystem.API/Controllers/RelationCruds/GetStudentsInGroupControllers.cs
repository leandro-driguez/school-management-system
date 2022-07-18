
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Relations;
using Microsoft.EntityFrameworkCore; 
using AutoMapper;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GetStudentsInGroupController : Controller
{
    public readonly IStudentCourseGroupRelationService _service;
    public readonly IMapper mapper;
    
    public GetStudentsInGroupController(IStudentCourseGroupRelationService service, IMapper mapper)
    {
        _service = service;
        this.mapper = mapper;
    }

    [HttpGet("id")]
    public IActionResult GetBygroup(string coursePLUSgroupId)
    {
        var ids = coursePLUSgroupId.Split('&');
        var courseId = ids[0]; var groupId = ids[1];
        var _query = _service.Query().Where(c => c.CourseGroupCourseId == courseId && c.CourseGroupId == groupId).Include(c => c.CourseGroup.Course).Include(c => c.Student);
        var output = new List<Object>();   
        foreach (var item in _query)
        {
            var dto = new {
                StudentId = item.StudentId,
                StudentName = item.Student.Name,
                StudentLastName = item.Student.LastName,
                StudentIdCardNo = item.Student.IDCardNo,
                StartDate = item.StartDate               
            };
            output.Add(dto);
        }
        return Ok(output);
    }


}
