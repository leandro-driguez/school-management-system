
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Relations;
using SchoolManagementSystem.Application.Repositories_Interfaces;
using Microsoft.EntityFrameworkCore; 
using AutoMapper;
using System.Collections.Generic;
using System.Collections;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoStudentPaymentController : Controller
{    
    public readonly IDoStudentPaymentService _servicePayment;
    public readonly IMapper mapper;

    public DoStudentPaymentController(IDoStudentPaymentService servicePayment,
        IMapper mapper)
    {        
        _servicePayment = servicePayment;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll([FromQuery] string id)
    {
        //return Ok("Hola");        
        return Ok( GroupCurseNoPaid(id).ToList());
        //return Ok(new IList[] { q3.ToList(), q4.ToList(), q5.ToList() });
    }

    [HttpPost]
    public IActionResult Post([FromForm] StudentIdGroupIdDto dto)
    {
        var groupCurseNoPaid = (from g in GroupCurseNoPaid(dto.StudentId)
                                where g.GroupId == dto.GroupId
                                select g)
                                .FirstOrDefault();
        if (groupCurseNoPaid == null)
        {
            return NotFound(dto);
        }
        groupCurseNoPaid.DatePaid = groupCurseNoPaid.DatePaid.Date.AddDays(30);
        _servicePayment.DoCoursePayment(groupCurseNoPaid.StudentId,
                                        groupCurseNoPaid.GroupId,
                                        groupCurseNoPaid.CourseId,
                                        groupCurseNoPaid.DatePaid);
        return Ok(groupCurseNoPaid);
    }

    private IQueryable<StudentGroupPaymentDto> GroupCurseNoPaid(string studentId)
    {
        // cursos-grupo que ya ha ido pagando el estudiante
        var q1 = from record in _servicePayment.GetStudentPaymentRecordPerCourseGroupRepo().Query()
                 where record.StudentId == studentId
                 select record.CourseGroupId;
        // cursos-grupo en los que no ha pagado aún
        // solo tiene los que nunca ha pagado ni una vez
        var q2 = from relation in _servicePayment.GetStudentCourseGroupRelationRepo().Query()
                 where relation.StudentId == studentId
                 where !q1.Contains(relation.CourseGroupId)
                 select new StudentGroupPaymentDto
                 {
                     StudentId = relation.StudentId,
                     GroupId = relation.CourseGroupId,
                     CourseId = relation.CourseGroupCourseId,
                     DatePaid = relation.CourseGroup.StartDate,
                     Date = relation.StartDate,
                 };

        // de los registros de pago del estudiante determinado y su grupo de clase
        // agrupar los registros por el grupo de clase
        // tomando la última fecha de pago
        var q3 = from record in _servicePayment.GetStudentPaymentRecordPerCourseGroupRepo().Query()
                 where record.StudentId == studentId
                 group record by record.CourseGroupId into g
                 select new
                 {
                     StudentId = g.Select(r => r.StudentId).FirstOrDefault(),
                     CourseGroupId = g.Select(r => r.CourseGroupId).FirstOrDefault(),
                     CourseGroupCourseId = g.Select(r => r.CourseGroupCourseId).FirstOrDefault(),
                     DatePaid = g.Max(r => r.DatePaid),
                     Date = g.Max(r => r.Date),
                 };
        var q4 = from record in q3
                 join relation in _servicePayment.GetStudentCourseGroupRelationRepo().Query()
                 on new
                 {
                     record.StudentId,
                     record.CourseGroupId,
                     record.CourseGroupCourseId,
                 } equals new
                 {
                     relation.StudentId,
                     relation.CourseGroupId,
                     relation.CourseGroupCourseId,
                 }
                 select new
                 {
                     StudentId = record.StudentId,
                     CourseGroupId = record.CourseGroupId,
                     CourseGroupCourseId = record.CourseGroupCourseId,
                     DatePaid = record.DatePaid,
                     EndDate = relation.EndDate,
                     Date = record.Date,
                 };
        var q5 = from r in q4
                 where r.DatePaid.Date < r.EndDate.Date
                 select new StudentGroupPaymentDto
                 {
                     StudentId = r.StudentId,
                     GroupId = r.CourseGroupId,
                     CourseId = r.CourseGroupCourseId,
                     DatePaid = r.DatePaid,
                     Date = r.Date
                 };
        return q2.Union(q5);
    }
}
