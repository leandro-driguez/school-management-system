
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Repositories_Interfaces;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class StudentPayCourseRecordService : BaseRecordService<StudentPaymentRecordPerCourseGroup>, IStudentPayCourseRecordService
{
    public StudentPayCourseRecordService(IStudentPayCourseRecordRepository repository) : base(repository)
    {

    }
}