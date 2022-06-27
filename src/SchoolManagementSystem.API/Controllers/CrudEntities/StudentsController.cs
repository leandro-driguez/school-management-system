
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Enums;
using SchoolManagementSystem.Domain.Relations;
using AutoMapper;
using SchoolManagementSystem.API.Controllers;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSystem.API.Controllers.CrudEntities;

public class StudentsController : CrudController<Student, StudentDto>
{
    
    public StudentsController(IStudentService service, 
        IMapper mapper) : base(service ,mapper)
    {
    }

    [HttpPost]
    public override IActionResult Post([FromBody] StudentDto dto_model)
    {
        var tuitor = new Tuitor 
        { 
            Name = dto_model.TuitorName, 
            PhoneNumber = dto_model.TuitorPhoneNumber,
            Students = new List<Student>() 
        };

        var studentTuitor = _service.Query()
                    .Where(
                        s => s.Tuitor.Name == dto_model.TuitorName
                            && s.Tuitor.PhoneNumber == dto_model.TuitorPhoneNumber
                    )
                    .FirstOrDefault();

        if (studentTuitor is not null)
        {
            tuitor = studentTuitor.Tuitor;
        }

        var scholarityLevel = _mapperToDto.Map<Education>(dto_model.ScholarityLevel);


        var student = _mapperToDto.Map<Student>(dto_model);

        student.Tuitor = tuitor;
        student.StudentCourseGroupRelations = new List<StudentCourseGroupRelation>();
        student.ScholarityLevel = scholarityLevel;
        
        _service.Add(student);
        _service.CommitAsync();
        
        return Ok(dto_model);
    }

}
