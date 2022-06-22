
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Services;
public interface IConsultWorkerSalaryService 
{
    public List<int> Proof();

    public List<Tuple<string, int>> GetWorkerFixSalaries(string id);

}