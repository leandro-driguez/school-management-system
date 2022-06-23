
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Repositories_Interfaces;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class ExpenseRecordService : BaseRecordService<ExpenseRecord>, IExpenseRecordService
{
    public ExpenseRecordService(IExpenseRecordRepository repository) : base(repository)
    {

    }
}