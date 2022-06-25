using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Persistence;
using SchoolManagementSystem.Application.Repositories_Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class StudentPayCourseRecordRepository : RecordRepository<StudentPaymentRecordPerCourseGroup>, IStudentPayCourseRecordRepository
{
    public StudentPayCourseRecordRepository(IObjectContext context) : base(context)
    {

    }
}