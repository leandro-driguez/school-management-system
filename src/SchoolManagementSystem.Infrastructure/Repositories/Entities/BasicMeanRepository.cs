using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Application.Repositories_Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class BasicMeanRepository : CrudRepository<BasicMean>, IBasicMeanRepository
{
    public BasicMeanRepository(IObjectContext context) : base(context)
    {

    }
}
