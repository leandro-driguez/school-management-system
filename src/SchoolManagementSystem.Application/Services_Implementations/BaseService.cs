
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Application;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class BaseService<TEntity> : IService<TEntity> where TEntity : class
{
    public BaseService(IRepository<TEntity> repository)
    {
        BaseRepository = repository;
    }

    protected IRepository<TEntity> BaseRepository { get; }
    
    public IQueryable<TEntity> Query() => BaseRepository.Query();
    
    public void Add(TEntity entity) => BaseRepository.Add(entity);

    public void Update(TEntity entity) => BaseRepository.Update(entity);

    public void Remove(TEntity entity) => BaseRepository.Remove(entity);

    public void Commit() => BaseRepository.Commit();

    public Task CommitAsync() => BaseRepository.CommitAsync();

}
