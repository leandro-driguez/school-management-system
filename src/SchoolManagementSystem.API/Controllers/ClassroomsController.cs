
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClassroomsController : Controller
{
    private readonly IService<Classroom> _service;
    private readonly Func<Classroom, ClassroomDto> _mapperToDto;
    
    public ClassroomsController(IService<Classroom> service, 
        IMapper<Classroom, ClassroomDto> mapperToDto)
    {
        _service = service;
        _mapperToDto = mapperToDto.Mapper();
    }

    [HttpGet]
    public IActionResult GetClassrooms()
    {
        return Ok
        (
            _service.Query()
                .Select(_mapperToDto)
                .ToList()
        );
    }
    
    [HttpGet("{id}")]
    public IActionResult GetClassroomById(string id)
    {
        var classrooms = _service.Query()
            .Where(c => c.Id == id);

        foreach (var classroom in classrooms)
        {
            return Ok(classroom);
        }

        return BadRequest();
    }

    [HttpPost]
    public IActionResult PostClassroom([FromForm] ClassroomDto classroomDto)
    {   
        _service.Add(new Classroom
        {
            Name = classroomDto.Name,
            Capacity = classroomDto.Capacity,
            Shifts = new List<Shift>()
        });
        
        _service.CommitAsync();
        
        return Ok();
    }

    [HttpPut]
    public IActionResult PutClassroom([FromForm] ClassroomDto classroomDto)
    {
        var classrooms = _service.Query()
            .Where(c => c.Id == classroomDto.Id);

        foreach (var classroom in classrooms.Take(1))
        {
            classroom.Name = classroomDto.Name;
            classroom.Capacity = classroomDto.Capacity;
            
            _service.Update(classroom);
    
            _service.CommitAsync();
    
            return GetClassroomById(classroomDto.Id);
        }

        return BadRequest();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteClassroom(string id)
    {
        var classrooms = _service.Query()
            .Where(c => c.Id == id);

        foreach (var classroom in classrooms.Take(1))
        {
            _service.Remove(classroom);

            _service.CommitAsync();

            return Ok();
        }
        
        return BadRequest();
    }
}
