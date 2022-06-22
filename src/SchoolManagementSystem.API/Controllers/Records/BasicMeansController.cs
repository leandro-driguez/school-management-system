
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Services;
using AutoMapper;
using SchoolManagementSystem.API.Controllers;

namespace SchoolManagementSystem.API.Controllers.CrudEntities;

public class StudentPayCourseRecordController : RecordController<StudentPaymentRecordPerCourseGroup, BasicMeanDto>
{   
    public StudentPayCourseRecordController(IStudentPayCourseRecordService service//, 
        /*IMapper mapper*/) : base(service)
    {
    }
}
