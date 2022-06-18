using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories;

// public class TeacherRepository : IRepository<Teacher>
// {
//     SchoolContext _context;

//     public TeacherRepository(SchoolContext context)
//     {
//         _context = context;
//     }

//     public IList<Teacher> GetAll()
//     {
//         return _context.Teachers.ToList();
//     }

//     public void Save()
//     {
//         _context.SaveChangesAsync();
//     }
// }