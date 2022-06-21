
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
    private readonly Func<ClassroomDto, Classroom> _mapperToEntity;
    
    public ClassroomsController(IService<Classroom> service, 
        IMapper<Classroom, ClassroomDto> mapperToDto, 
        IMapper<ClassroomDto, Classroom> mapperToEntity)
    {
        _service = service;
        _mapperToDto = mapperToDto.Mapper();
        _mapperToEntity = mapperToEntity.Mapper();
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
    public IActionResult GetClassroomById(string id, IMapper<ClassroomDto, Classroom> mapper)
    {
        var classroom = (Classroom)_service
            .FilterBy(c => c.Id == id)
            .Take(1);
    
        return Ok(classroom);
    }

    [HttpPost]
    public IActionResult PostClassroom([FromForm] ClassroomDto classroom)
    {
        try
        {
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
