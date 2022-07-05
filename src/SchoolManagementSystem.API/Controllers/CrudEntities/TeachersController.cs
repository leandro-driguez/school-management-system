
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

public class TeachersController : CrudController<Teacher, TeacherDto>
{
    
    public TeachersController(ITeacherService service, 
        IMapper mapper) : base(service ,mapper)
    {

        
    }
    [HttpPost("{id}")]
    public virtual IActionResult BecomeTeacher(string id)
    {
        var _serv = (_service as ITeacherService);
        if(!_serv.BecomeTeacher(id))
            return NotFound();

        return Ok();
    }


    [HttpDelete]
    public override IActionResult Delete(string id)
    {
        var teachers = _service.Query()
            .AsNoTrackingWithIdentityResolution().Include(c => c.WorkerPositionRelations )
                                            .Include(c => c.TeacherCourseGroupRelations);
        var teacher = teachers.FirstOrDefault(c => Equals(c.Id, id));
        
        if(teacher == null)
            return NotFound(id);

        foreach(var rel in teacher.WorkerPositionRelations)
        {
            if (DateTime.Now <  rel.EndDate)
            {
                rel.EndDate = DateTime.Now;
            }
        }

        foreach(var rel in teacher.TeacherCourseGroupRelations)
        {
            if (DateTime.Now <  rel.EndDate)
            {
                rel.EndDate = DateTime.Now;
            }
        }

        return base.Delete(id);
    }
}
