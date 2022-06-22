
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using AutoMapper;
using SchoolManagementSystem.API.Controllers;

namespace SchoolManagementSystem.API.Controllers.CrudEntities;

public class StudentsController : CrudController<Student, StudentDto>
{
    
    public StudentsController(IStudentService service, 
        IMapper mapper) : base(service ,mapper)
    {
    }
}
