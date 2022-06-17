using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class PositionRepository : IRepository<Position>
{
    SchoolContext _context;

    public PositionRepository(SchoolContext context)
    {
        _context = context;
    }

    public IList<Position> GetAll()
    {
        return _context.Positions.ToList();
    }

    public void Save()
    {
        _context.SaveChangesAsync();
    }
}