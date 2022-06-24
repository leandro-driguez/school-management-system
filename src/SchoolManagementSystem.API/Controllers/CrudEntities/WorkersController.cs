
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using Microsoft.EntityFrameworkCore;  
using AutoMapper;
using SchoolManagementSystem.API.Controllers;

namespace SchoolManagementSystem.API.Controllers.CrudEntities;

public class WorkersController : CrudController<Worker, WorkerDto>
{
    
    public WorkersController(IWorkerService service, 
        IMapper mapper) : base(service ,mapper)
    {
    }

    [HttpGet]
    public override IActionResult GetAll()
    {
        return Ok
        (
            _service.Query()
                .Select(_mapperToDto.Map<Worker, WorkerDto>)
                .Select((dto) => {
                    dto.Id = dto.Id.Substring(25);
                    return dto;
                })
                .ToList()
        );
    }

    [HttpPost]
    public override IActionResult Post([FromBody] WorkerDto dto_model)
    {
        var entity = _mapperToDto.Map<Worker>(dto_model);
        
        _service.Add(entity);
        _service.CommitAsync();

        return Ok(dto_model);
    }

    [HttpPut]
    public override IActionResult Put([FromBody] WorkerDto dto_model)
    {
        var id = _mapperToDto.Map<Worker>(dto_model).Id;

        var worker = _service.Query()
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefault(c => Equals(c.Id, id));

        if(worker == null)
            return NotFound(dto_model);

        _mapperToDto.Map(dto_model, worker);
        _service.Update(worker);
        _service.CommitAsync();

        return Ok(worker);
    }

    [HttpDelete("{id}")]
    public override IActionResult Delete(string id)
    {
        var Id = new SchoolMember{Id = id}.Id;
        
        var worker = _service.Query()
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefault(c => Equals(c.Id, Id));
        
        if(worker == null)
            return NotFound(id);
        
        _service.Remove(worker);
        _service.CommitAsync();
        
        return Ok(worker);
    }
}
