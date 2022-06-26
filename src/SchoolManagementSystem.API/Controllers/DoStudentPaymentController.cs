
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
    public IActionResult GetAll([FromForm] string id)
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
        // de los registros de pago del estudiante determinado y su grupo de clase
        // agrupar los registros por el grupo de clase
        // tomando la última fecha de pago
        var q1 = from record in _serviceRecord.Query()
                 where record.StudentId == dto.StudentId &&
                        record.CourseGroupId == dto.GroupId
                 group record by record.CourseGroupId into g
                 select new
                 {
                     StudentId = g.Select(r => r.StudentId).FirstOrDefault(),
                     CourseGroupId = g.Select(r => r.CourseGroupId).FirstOrDefault(),
                     CourseGroupCourseId = g.Select(r => r.CourseGroupCourseId).FirstOrDefault(),
                     Date = g.Select(r => r.Date).FirstOrDefault(),
                     DatePaid = g.Max(r=>r.DatePaid)
                 };
        if (q1.Count() > 1)     
            // Este Exception jamás debe ocurrir
            throw new Exception("En StudentCourseGroupRecord hay más de un Curso " +
                                "con el mismo StudentId y GroupCourseId");
        if (q1.Any())
        {
            var q2 = from relation in _serviceRelation.Query()
                     where relation.StudentId == dto.StudentId &&
                           relation.CourseGroupId == dto.GroupId
                     select relation.EndDate;
            if (q2.Count() != 1)
                // Este Exception jamás debe ocurrir
                throw new Exception("En StudentCourseGroupRelation hay más de un Curso " +
                                    "con el mismo StudentId y GroupCourseId" +
                                    "o no existe la relación");
            var finalDate = q2.First().Date;
            if (finalDate >= q1.First().Date)
            {
                // Ya se pagó todo el curso
                return BadRequest("Ya el curso estaba pagado");
            }
            // Se supone que ahora se procede a cobrar
            // O sea a guardar el curso en la base de datos
            Ok("Cobro de curso realizada");
        }
        // IMPORTANTE
        // Falta la parte de revisar en los cursos que jamás se han pagado

        //var q2 = from record in q1
        //         where record.StudentId == dto.StudentId &&
        //                record.CourseGroupId == dto.GroupId
        //         select record;

        //var ultimo_mes_pagado = q1.Select(r => r.DatePaid).FirstOrDefault();
        return Ok(q1.ToList());
        //if (ultimo_mes_pagado )
        //{
        //     antes habria que comprobar si está en la tabla de relaciones
        //     para entonces incluirlo en los records
        //    return NotFound(dto);
        //}
        // Faltaría meterlo como tal ahora
        throw new NotImplementedException();
    }
}
