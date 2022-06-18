using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories;

// public class TuitorRepository : IRepository<Tuitor>
// {
//     SchoolContext _context;

//     public TuitorRepository(SchoolContext context)
//     {
//         _context = context;
//     }

//     public IList<Tuitor> GetAll()
//     {
//         return _context.Tuitors.ToList();
//     }

//     public void Save()
//     {
//         _context.SaveChangesAsync();
//     }
// }