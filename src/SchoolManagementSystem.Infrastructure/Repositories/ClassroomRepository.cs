
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class ClassroomRepository : IRepository<Classroom>
{
    SchoolContext _context;

    public ClassroomRepository(SchoolContext context)
    {
        _context = context;
    }

    public IList<Classroom> GetAll()
    {
        return _context.Classrooms.ToList();
    }

    public void Save()
    {
        _context.SaveChangesAsync();
    }

    // public void Create(Classroom entity)
    // {
    //     _context.Classrooms.AddRangeAsync(entity);
    //     _context.SaveChangesAsync();
    // }

    // public Classroom Read(Guid entityId)
    // {
    //     return _context.Classrooms.FirstOrDefault(c => c.Id.Equals(entityId));
    // }

    // public void Update(Classroom entity)
    // {
    //     _context.Classrooms.UpdateRange(entity);
    // }

    // public void Delete(Guid entityId)
    // {
    //     _context.Classrooms.RemoveRange(Read(entityId));
    // }
}
