
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

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoStudentPaymentController : Controller
{
    public readonly IStudentCourseGroupRelationService _serviceRelation;
    public readonly IStudentPayCourseRecordService _serviceRecord;
    public readonly IStudentRepository _studentRepository;
    IDoStudentPaymentService _servicePayment;
    public readonly IMapper mapper;
    
    public DoStudentPaymentController(IStudentCourseGroupRelationService serviceRelation,
        IStudentPayCourseRecordService serviceRecord,
        IStudentRepository studentRepository,
        IDoStudentPaymentService servicePayment, IMapper mapper)
    {
        _serviceRelation = serviceRelation;
        _serviceRecord = serviceRecord;
        _studentRepository = studentRepository;
        _servicePayment = servicePayment;
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
        return Ok(_servicePayment.DoCoursePayment(dto.StudentId, dto.GroupId));
    }
}
