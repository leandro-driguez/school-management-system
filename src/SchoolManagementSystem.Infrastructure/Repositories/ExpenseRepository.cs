using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories;

// public class ExpenseRepository : IRepository<Expense>
// {
//     SchoolContext _context;

//     public ExpenseRepository(SchoolContext context)
//     {
//         _context = context;
//     }

//     public IList<Expense> GetAll()
//     {
//         return _context.Expenses.ToList();
//     }

//     public void Save()
//     {
//         _context.SaveChangesAsync();
//     }
// }