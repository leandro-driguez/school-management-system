
namespace SchoolManagementSystem.Domain.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> Query();
    void AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    void SaveAsync();
}
