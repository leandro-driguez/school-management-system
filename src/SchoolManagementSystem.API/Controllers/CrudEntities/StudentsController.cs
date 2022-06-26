
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

    [HttpGet]
    public override IActionResult GetAll()
    {
        return Ok
        (
            _service.Query()
                .Select(_mapperToDto.Map<Student,StudentDto>)
                //.Select((dto) => {
                //    dto.Id = dto.Id.Substring(25);
                //    return dto;
                //})
                .ToList()
        );
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

    [HttpPut]
    public override IActionResult Put([FromBody] StudentDto dto_model)
    {
        var id = _mapperToDto.Map<Student>(dto_model).Id;

        var student = _service.Query()
            .FirstOrDefault(c => Equals(c.Id, id));

        if(student == null)
            return NotFound(dto_model);

        _mapperToDto.Map(dto_model, student);
        _service.Update(student);
        _service.CommitAsync();

        return Ok();
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
