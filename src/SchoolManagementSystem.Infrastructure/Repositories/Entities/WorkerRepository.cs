using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Application.Repositories_Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class WorkerRepository : CrudRepository<Worker>, IWorkerRepository
{
    public WorkerRepository(IObjectContext context) : base(context)
    {

    }
}