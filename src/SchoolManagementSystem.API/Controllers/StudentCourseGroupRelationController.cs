
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
    public IActionResult Post([FromForm]StudentCourseGroupRelationPostDto dto)
    {
        if(!_service.AddStudentToCourseGroup(dto.StudentsId, dto.CourseGroupId, dto.CourseId))
            return NotFound();
        return Ok();
    }

}
