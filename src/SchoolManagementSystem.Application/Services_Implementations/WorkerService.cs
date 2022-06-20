
using SchoolManagementSystem.Application.Repositories_Interfaces;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class WorkerService : BaseService<Worker>, IWorkerService
{
    public WorkerService(IWorkerRepository repository) : base(repository)
    {

    }
}