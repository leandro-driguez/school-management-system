using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Persistence;
using SchoolManagementSystem.Application.Repositories_Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class ExpenseRecordRepository : RecordRepository<ExpenseRecord>, IExpenseRecordRepository
{
    public ExpenseRecordRepository(IObjectContext context) : base(context)
    {

    }
}