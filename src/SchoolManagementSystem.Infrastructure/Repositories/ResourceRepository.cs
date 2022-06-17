using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class ResourceRepository : IRepository<Resource>
{
    SchoolContext _context;

    public ResourceRepository(SchoolContext context)
    {
        _context = context;
    }

    public IList<Resource> GetAll()
    {
        return _context.Resources.ToList();
    }

    public void Save()
    {
        _context.SaveChangesAsync();
    }
}