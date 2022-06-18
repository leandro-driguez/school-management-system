
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class ClassroomRepository : Crudrep
{
    SchoolContext _context;

    public ClassroomRepository(SchoolContext context)
    {
        _context = context;
    }
    
    public IQueryable<Classroom> Query()
    {
        return _context.Classrooms;
    }

    public void AddAsync(Classroom entity)
    {
        _context.Classrooms.AddAsync(entity);
    }

    public void Update(Classroom entity)
    {
        _context.Classrooms.Update(entity);
    }

    public void Remove(Classroom entity)
    {
        _context.Classrooms.Remove(entity);
    }

    public void SaveAsync()
    {
        _context.SaveChangesAsync();
    }
}
