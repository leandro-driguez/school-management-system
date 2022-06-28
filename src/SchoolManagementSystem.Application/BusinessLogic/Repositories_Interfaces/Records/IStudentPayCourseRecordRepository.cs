
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Domain.Records;

namespace SchoolManagementSystem.Application.Repositories_Interfaces;

public interface IStudentPayCourseRecordRepository : IRecordRepository<StudentPaymentRecordPerCourseGroup>
{
    
}