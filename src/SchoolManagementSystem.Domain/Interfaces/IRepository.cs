
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Interfaces;

public interface IRepository<TEntity> where TEntity : Entity
{
    void Save();
    IList<TEntity> GetAll();
}
