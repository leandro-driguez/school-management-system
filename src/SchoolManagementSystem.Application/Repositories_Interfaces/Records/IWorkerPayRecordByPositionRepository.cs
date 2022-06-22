


using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;

namespace SchoolManagementSystem.Application.Repositories_Interfaces.Records;

public interface IWorkerPayRecordByPositionRepository : IRecordRepository<WorkerPayRecordByPosition>
{
    // public Dictionary<Position, int> GetWorkerFixSalaries();
}