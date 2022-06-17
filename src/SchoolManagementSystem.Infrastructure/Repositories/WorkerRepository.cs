using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class WorkerRepository : IRepository<Worker>
{
    SchoolContext _context;

    public WorkerRepository(SchoolContext context)
    {
        _context = context;
    }

    public IList<Worker> GetAll()
    {
        return _context.Workers.ToList();
    }

    public void Save()
    {
        _context.SaveChangesAsync();
    }
}