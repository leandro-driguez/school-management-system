
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Application.Repositories_Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class UserRepository : CrudRepository<User>, IUserRepository
{
    public UserRepository(IObjectContext context) : base(context)
    {

    }
}
