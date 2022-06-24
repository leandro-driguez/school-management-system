
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Enums;
using SchoolManagementSystem.Domain.Relations;
using AutoMapper;
using SchoolManagementSystem.API.Controllers;

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

        var entity = new Student
        {
            Id = dto_model._id,
            Name = dto_model.Name,
            LastName = dto_model.LastName,
            PhoneNumber = dto_model.PhoneNumber,
            Address = dto_model.Address,
            DateBecomedMember = dto_model.DateBecomedMember,
            Tuitor = tuitor,
            Founds = dto_model.Founds,
            ScholarityLevel = scholarityLevel,
            StudentCourseGroupRelations = new List<StudentCourseGroupRelation>()
        };
        
        _service.Add(entity);
        _service.CommitAsync();
        
        return Ok(dto_model);
    }
}
