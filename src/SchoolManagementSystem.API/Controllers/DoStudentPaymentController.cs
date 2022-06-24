
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

    [HttpGet]
    public IActionResult GetAll()
    {
        // cursos y estudiantes de las relaciones
        //var q1 = from relation in _serviceRelation.Query()
        //         select new CourseStudent
        //         {
        //             CourseId = relation.CourseGroup.CourseId,
        //             StudentId = relation.StudentId
        //         };
        //// cursos y estudiantes pagados 
        //var q2 = from record in _serviceRecord.Query()
        //         select new CourseStudent
        //         {
        //             CourseId = record.CourseGroup.CourseId,
        //             StudentId = record.StudentId
        //         };

        //var q3 = from relation in q1.AsEnumerable()
        //         where !q2.AsEnumerable().Contains(relation)
        //         select relation;

        //return Ok(q3.ToList());
        //return Ok(new IList[] { q3.ToList(), q4.ToList(), q5.ToList() });
    }
}
