
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using AutoMapper;
using SchoolManagementSystem.API.Controllers;

namespace SchoolManagementSystem.API.Controllers.CrudEntities;

// [ApiController]
// [Route("api/[controller]")]
public class ClassroomsController : CrudControlller<Classroom, ClassroomDto>
{
    private readonly IService<Classroom> _service;
    private readonly IMapper _mapperToDto;
    
    public ClassroomsController(IClassroomService service, 
        IMapper mapper) : base(service ,mapper)
    {
        _service = service;
        _mapperToDto = mapper;
    }

    // [HttpGet]
    // public IActionResult GetClassrooms()
    // {
    //     return base.GetAll();
    // }
    
    // [HttpGet("{id}")]
    // public IActionResult GetClassroomById(string id)
    // {
    //     return base.GetItemById(id);
    // }

    [HttpPost]
    public override IActionResult Post([FromForm] ClassroomDto classroomDto)
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

     [HttpPut("{id}")]
    public override IActionResult Put(string id, [FromForm] ClassroomDto classroomDto)
    {
        return base.Put(id,classroomDto);
    }

    [HttpDelete("{id}")]
    public override IActionResult Delete(string id)
    {
        return base.Delete(id);
    }
}
