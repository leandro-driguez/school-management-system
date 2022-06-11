
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Interfaces;

public interface IRepository<TEntity> where TEntity : Entity
{
    void Create(TEntity entity);
    TEntity Read(Guid entityId);
    void Update(TEntity entity);
    void Delete(Guid entityId);
    
    // Save
}
