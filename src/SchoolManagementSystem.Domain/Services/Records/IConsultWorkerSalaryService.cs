

using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;
// using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Services;
public interface IConsultWorkerSalaryService : IRecordService<Worker>
{
    public List<int> Proof();

    public IQueryable<TeacherPayRecordPerCourse> GetWorkerCoursePorcentualSalaries(string id, DateTime date);
    public IQueryable<WorkerPayRecordByPosition> GetWorkerFixSalariesByDate(string id, DateTime date);
    public List<DateTime> GetAllPaymentDates(string id);
    // public List<Tuple<string, double>> GetWorkerCoursePorcentualSalaries(string id);
    // public double GetTotalWorkerCoursePorcentualSalaries(string id);
    // public List<Tuple<string, int>> GetWorkerFixSalaries(string id);
    // public int GetTotalWorkerFixSalaries(string id);


}