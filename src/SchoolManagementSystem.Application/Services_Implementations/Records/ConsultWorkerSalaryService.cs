
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Application.Repositories_Interfaces.Records;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class ConsultWorkerSalaryService : IConsultWorkerSalaryService
{
    public ConsultWorkerSalaryService(IConsultWorkerSalaryRepository repo)
    {
    }
    public List<int> Proof()
    {
        return new List<int> { 1, 2, 3, 4 };
    }
    
    
    public Dictionary<Position, int> GetWorkerFixSalaries()
    {
        throw new NotImplementedException();
    }
}