
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using Microsoft.EntityFrameworkCore; 
using AutoMapper;
using SchoolManagementSystem.Domain.Records;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecordController<TEntity, TDTO> : Controller where TEntity :  Record where TDTO : IDto
{
    public readonly IRecordService<TEntity> _service;
    //public readonly IMapper _mapperToDto;
    
    public RecordController(IRecordService<TEntity> service)
        //IMapper mapperToDto)
    {
        _service = service;
        //_mapperToDto = mapperToDto;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok
        (
            _service.Query()
            //.Include(e => e.Date)
                //.Select(_mapperToDto.Map<TEntity,TDTO>)
                .ToList()
        );
    }

}
