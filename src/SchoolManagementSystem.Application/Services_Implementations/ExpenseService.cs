
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Repositories_Interfaces.Entities;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class ExpenseService : BaseService<Expense>, IExpenseService
{
    public ExpenseService(IExpenseRepository repository) : base(repository)
    {

    }

    public override IQueryable<Expense> Query()
    {
        return base.Query().Include(e => e.ExpenseRecords).AsNoTracking();
    }
}