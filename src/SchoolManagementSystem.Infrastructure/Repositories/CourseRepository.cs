using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories;

// public class CourseRepository : IRepository<Course>
// {
//     SchoolContext _context;

//     public CourseRepository(SchoolContext context)
//     {
//         _context = context;
//     }

//     public IList<Course> GetAll()
//     {
//         return _context.Courses.ToList();
//     }

//     public void Save()
//     {
//         _context.SaveChangesAsync();
//     }
// }