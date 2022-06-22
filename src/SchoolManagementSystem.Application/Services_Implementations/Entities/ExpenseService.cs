
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Repositories_Interfaces.Entities;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services.Entities;

namespace SchoolManagementSystem.Application.Services_Implementations.Entities;

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