
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using AutoMapper;
using SchoolManagementSystem.API.Controllers;

namespace SchoolManagementSystem.API.Controllers.CrudEntities;

public class ClassroomsController : CrudControlller<Classroom, ClassroomDto>
{
    // public readonly new IService<Classroom> _service;
    // public readonly IMapper _mapper;
    
    public ClassroomsController(IClassroomService service, 
        IMapper mapper) : base(service ,mapper)
    {
        // _service = service;
        // _mapper = mapper;
    }

    [HttpPost]
    public override IActionResult Post([FromForm] ClassroomDto classroomDto)
    {   
        return base.Post(classroomDto);
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
