
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


}
