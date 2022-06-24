
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Relations;
using Microsoft.EntityFrameworkCore; 
using AutoMapper;
using System.Collections.Generic;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoStudentPaymentController : Controller
{
    public readonly IStudentCourseGroupRelationService _serviceRelation;
    public readonly IStudentPayCourseRecordService _serviceRecord;
    public readonly IMapper mapper;
    
    public DoStudentPaymentController(IStudentCourseGroupRelationService serviceRelation,
        IStudentPayCourseRecordService serviceRecord, IMapper mapper)
    {
        _serviceRelation = serviceRelation;
        _serviceRecord = serviceRecord;
        this.mapper = mapper;
    }

    [HttpGet("{id}")]
    public IActionResult GetAll(string id)
    {
        // cursos-grupo que ya ha ido pagando el estudiante
        var q1 = from record in _serviceRecord.Query()
                 where record.StudentId == id
                 select record.CourseGroupId;

        
        //var q2 = from record in _serviceRecord.Query()
        //         group record by record.CourseGroupId into g
        //         select g.OrderByDescending(e => e.CourseGroupId).FirstOrDefault() into r
        //         select r;

        // cursos-grupo en los que no ha pagado aún
        // solo tiene los que nunca ha pagado ni una vez
        var q3 = from relation in _serviceRelation.Query()
                 where !q1.Contains(relation.CourseGroupId)
                 select relation;

        return Ok(q3.ToList());
        //return Ok(new IList[] { q3.ToList(), q4.ToList(), q5.ToList() });
    }

    [HttpPost]
    public IActionResult Post([FromForm] StudentIdGroupIdDto dto)
    {
        var q1 = from record in _serviceRecord.Query()
                 group record by record.CourseGroupId into g
                 select new
                 {
                     StudentId = g.Select(r => r.StudentId).FirstOrDefault(),
                     CourseGroupId = g.Select(r => r.CourseGroupId).FirstOrDefault(),
                     CourseGroupCourseId = g.Select(r => r.CourseGroupCourseId).FirstOrDefault(),
                     Date = g.Select(r => r.Date).FirstOrDefault(),
                     DatePaid = g.Max(r=>r.DatePaid)
                 };
        var q2 = from record in q1
                 where record.StudentId == dto.StudentId &&
                        record.CourseGroupId == dto.GroupId
                 select record;

        var ultimo_mes_pagado = q2.FirstOrDefault();
        if (ultimo_mes_pagado == null)
        {
            // antes habria que comprobar si está en la tabla de relaciones
            // para entonces incluirlo en los records
            return NotFound(dto);
        }
        // Faltaría meterlo como tal ahora
        throw new NotImplementedException();
    }
}
