
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Services;
public interface IConsultWorkerSalaryService : IRecordService<Worker>
{
    public List<int> Proof();
    
    public List<Tuple<string, double>> GetWorkerCoursePorcentualSalaries(string id);
    public double GetTotalWorkerCoursePorcentualSalaries(string id);
    public List<Tuple<string, int>> GetWorkerFixSalaries(string id);
    public int GetTotalWorkerFixSalaries(string id);


}