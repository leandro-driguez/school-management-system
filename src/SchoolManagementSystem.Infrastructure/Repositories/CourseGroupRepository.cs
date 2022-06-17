using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class CourseGroupRepository : IRepository<CourseGroup>
{
    SchoolContext _context;

    public CourseGroupRepository(SchoolContext context)
    {
        _context = context;
    }

    public IList<CourseGroup> GetAll()
    {
        return _context.CourseGroups.ToList();
    }

    public void Save()
    {
        _context.SaveChangesAsync();
    }
}