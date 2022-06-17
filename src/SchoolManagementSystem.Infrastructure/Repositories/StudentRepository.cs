using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class StudentRepository : IRepository<Student>
{
    SchoolContext _context;

    public StudentRepository(SchoolContext context)
    {
        _context = context;
    }

    public IList<Student> GetAll()
    {
        return _context.Students.ToList();
    }

    public void Save()
    {
        _context.SaveChangesAsync();
    }
}