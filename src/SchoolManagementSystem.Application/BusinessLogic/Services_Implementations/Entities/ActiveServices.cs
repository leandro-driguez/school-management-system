
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Entities;


namespace SchoolManagementSystem.Application.Services_Implementations;



public class ActiveService<TEntity> : BaseService<TEntity>, IActiveService<TEntity> where TEntity : Entity
{
    new IActiveRepository<TEntity> BaseRepository;
    public ActiveService(IActiveRepository<TEntity> repository) : base(repository)
    {
        BaseRepository = repository;
    }

    public IQueryable<TEntity> QueryAll()
    {
        var inac = BaseRepository.QueryInactives();
        var act = BaseRepository.Query();

        
        return inac.Union(act);
    }

    public IQueryable<TEntity> QueryInactives() => BaseRepository.QueryInactives();

}
