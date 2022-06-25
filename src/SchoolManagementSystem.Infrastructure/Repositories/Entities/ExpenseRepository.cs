using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Persistence;
using SchoolManagementSystem.Application.Repositories_Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class ExpenseRepository : CrudRepository<Expense>, IExpenseRepository
{
    public ExpenseRepository(IObjectContext context) : base(context)
    {

    }
}