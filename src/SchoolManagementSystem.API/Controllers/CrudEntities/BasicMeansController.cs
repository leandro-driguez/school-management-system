
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using AutoMapper;
using SchoolManagementSystem.API.Controllers;

namespace SchoolManagementSystem.API.Controllers.CrudEntities;

public class BasicMeanController : CrudControlller<BasicMean, BasicMeanDto>
{
    // public readonly new IService<BasicMean> _service;
    // public readonly IMapper _mapper;
    
    public BasicMeanController(IBasicMeanService service, 
        IMapper mapper) : base(service ,mapper)
    {
        // _service = service;
        // _mapper = mapper;
    }

    // [HttpPost]
    // public override IActionResult Post([FromForm] BasicMeanDto basicMeanDto)
    // {   
    //    return base.Post(basicMeanDto);
    // }

    //  [HttpPut("{id}")]
    // public override IActionResult Put(string id, [FromForm] BasicMeanDto classroomDto)
    // {
    //     return base.Put(id,classroomDto);
    // }

    // [HttpDelete("{id}")]
    // public override IActionResult Delete(string id)
    // {
    //     return base.Delete(id);
    // }
}
