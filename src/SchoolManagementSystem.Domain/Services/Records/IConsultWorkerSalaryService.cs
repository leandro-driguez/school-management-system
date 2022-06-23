

using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;
// using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Services;
public interface IConsultWorkerSalaryService : IRecordService<Worker>
{
    public IQueryable<TeacherPayRecordPerCourse> GetWorkerCoursePorcentualSalariesByDate(string id, DateTime date);
    public IQueryable<WorkerPayRecordByPosition> GetWorkerFixSalariesByDate(string id, DateTime date);
    public List<DateTime> GetAllPaymentDates(string id);

}