
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using AutoMapper;
using SchoolManagementSystem.API.Controllers;

namespace SchoolManagementSystem.API.Controllers.CrudEntities;

public class WorkersController : CrudController<Worker, WorkerDto>
{
    
    public WorkersController(IWorkerService service, 
        IMapper mapper) : base(service ,mapper)
    {
    }

    [HttpPost]
    public override IActionResult Post([FromBody] WorkerDto dto_model)
    {
        var entity = _mapperToDto.Map<Worker>(dto_model);
        
        _service.Add(entity);
        _service.CommitAsync();

        return Ok(dto_model);
    }
}
