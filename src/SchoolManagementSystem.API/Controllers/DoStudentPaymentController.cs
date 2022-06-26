
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

    [HttpGet]
    public IActionResult GetAll([FromQuery] string id)
    {
        //return Ok("Hola");
        var q1 = _servicePayment.GroupCurseNoPaid(id);
        List<object> l = new List<object>();
        foreach (var row in q1)
        {
            l.Add(row);
        }
        return Ok(l);
        //return Ok(new IList[] { q3.ToList(), q4.ToList(), q5.ToList() });
    }

    [HttpPost]
    public IActionResult Post([FromForm] StudentIdGroupIdDto dto)
    {
        return Ok(_servicePayment.DoCoursePayment(dto.StudentId, dto.GroupId));
    }
}
