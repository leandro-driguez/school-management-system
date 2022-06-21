
namespace SchoolManagementSystem.Domain.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    IObjectContext Context {get; }

    IQueryable<TEntity> Query();
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    // void SaveAsync();
    void Commit();
    Task CommitAsync();
}
