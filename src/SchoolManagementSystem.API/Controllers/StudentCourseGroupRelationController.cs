
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
public class StudentCourseGroupRelationController : Controller
{
    public readonly IStudentCourseGroupRelationService _service;
    
    public StudentCourseGroupRelationController(IStudentCourseGroupRelationService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Post([FromForm]StudentCourseGroupRelationPostDto dto)
    {
        if(!_service.ValidateIds(dto.StudentId, dto.CourseGroupId, dto.CourseId))
            return NotFound();
        _service.Add(new StudentCourseGroupRelation
        {
            CourseGroupId = dto.CourseGroupId,
            StudentId = dto.StudentId,
            CourseGroupCourseId = dto.CourseId,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate
        });
        _service.CommitAsync();
        // _service.AddStudentsToCourseGroup(dto.StudentId, dto.CourseGroupId, dto.CourseId);
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete([FromForm]StudentCourseGroupRelationPostDto dto)
    {
        if(!_service.ValidateIds(dto.StudentId, dto.CourseGroupId, dto.CourseId))
            return NotFound();
        _service.DeleteStudentsFromCourseGroup(dto.StudentId, dto.CourseGroupId, dto.CourseId);
        return Ok();
    }

}
