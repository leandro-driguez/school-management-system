
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Relations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SchoolManagementSystem.Infrastructure.Configurations;
using SchoolManagementSystem.Infrastructure.Configurations.Records;
using SchoolManagementSystem.Infrastructure.Configurations.Relations;
using Microsoft.AspNetCore.Identity;

namespace SchoolManagementSystem.Infrastructure.Persistence;

public class IdentityContext : IdentityDbContext<IdentityUser>, IObjectContext
{
    public IdentityContext (DbContextOptions<IdentityContext> options)
        : base(options)
    {        
    }

    #region Methods and Properties

    IQueryable<TEntity> IObjectContext.Query<TEntity>() => Set<TEntity>();

    void IObjectContext.Add<TEntity>(TEntity entity) => Set<TEntity>().Add(entity);

    void IObjectContext.Update<TEntity>(TEntity entity) => Set<TEntity>().Update(entity);

    void IObjectContext.Remove<TEntity>(TEntity entity) => Set<TEntity>().Remove(entity);

    void IObjectContext.Commit() => SaveChanges();

    Task IObjectContext.CommitAsync() => SaveChangesAsync();

    #endregion

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
