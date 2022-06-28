
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Application.Repositories_Interfaces;
using SchoolManagementSystem.Domain.Relations;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Infrastructure.Repositories;
using SchoolManagementSystem.Infrastructure.Configurations.Relations;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class ShiftRepository :  CrudRepository<Shift>, IShiftRepository
    {
        public ShiftRepository(IObjectContext context) : base(context)
        {
     
        }
    }

}
