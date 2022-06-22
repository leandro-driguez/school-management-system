using SchoolManagementSystem.Application.Repositories_Interfaces.Records;

using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Relations;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Infrastructure.Configurations.Records;
using SchoolManagementSystem.Infrastructure.Configurations.Relations;

namespace SchoolManagementSystem.Infrastructure.Repositories.Records
{
    public class ConsultWorkerSalaryRepository :  RecordRepository<Worker>, IConsultWorkerSalaryRepository
    {
        // SchoolContext _context;
        public ConsultWorkerSalaryRepository(IObjectContext context) : base(context)
        {
            // _context = (SchoolContext)context;
        }
        // public Dictionary<Position, int> GetWorkerFixSalaries()
        // {
        //     throw new NotImplementedException();
        // }
    }

}
