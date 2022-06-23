

using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;
// using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Services;
public interface IDoWorkersPaymentService : IRecordService<Worker>
{
    public IQueryable<TeacherPayRecordPerCourse> GetWorkerCoursePorcentualSalaries(string id);
    public IQueryable<WorkerPayRecordByPosition> GetWorkerFixSalaries(string id);
    // public List<DateTime> GetAllPaymentDates(string id);

}