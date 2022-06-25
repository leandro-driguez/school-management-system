using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Persistence;
using SchoolManagementSystem.Application.Repositories_Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class TuitorRepository : CrudRepository<Tuitor>, ITuitorRepository
{
    public TuitorRepository(IObjectContext context) : base(context)
    {

    }
}