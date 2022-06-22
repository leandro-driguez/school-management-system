
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using Microsoft.EntityFrameworkCore; 
using AutoMapper;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentCourseGroupRelationController : Controller
{
    public readonly IStudentCourseGroupRelationService _service;
    
    public StudentCourseGroupRelationController(IStudentCourseGroupRelationService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Post(StudentCourseGroupRelationPostDto dto)
    {
        var _query = _service.Query();
        CourseGroup cg = _query.Include(c => c.CourseGroup)
                            .Where(c => c.CourseGroupId == dto.CourseGroupId)
                            .FirstOrDefault().CourseGroup;
        if(cg == null)
            return NotFound();
        foreach (var studentId in dto.StudentsId)
        {
            var std = _query.Where(c => c.StudentId == studentId)
                                .FirstOrDefault().StudentId;
            if(std == null)
                return NotFound();
        }



        return Ok();
    }

}
