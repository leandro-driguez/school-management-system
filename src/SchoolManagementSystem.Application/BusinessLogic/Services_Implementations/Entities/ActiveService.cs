
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class ActiveService<TEntity> : BaseService<TEntity> where TEntity : Entity
{
    public ActiveService(IRepository<TEntity> repository) : base(repository)
    {

    }

    public bool QueryAll()
    {

        throw new NotImplementedException();
    }

    public bool QueryInactive()
    {
        throw new NotImplementedException();
    }

}
