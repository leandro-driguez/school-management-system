
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Interfaces;

namespace SchoolManagementSystem.Infrastructure.Data;

public class IdentityContext : IdentityDbContext<IdentityUser>, IObjectContext
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }

    IQueryable<TIdentity> IObjectContext.Query<TIdentity>() => Set<TIdentity>();

    void IObjectContext.Add<TIdentity>(TIdentity identity) => Set<TIdentity>().Add(identity);

    void IObjectContext.Update<TIdentity>(TIdentity identity) => Set<TIdentity>().Update(identity);

    void IObjectContext.Remove<TIdentity>(TIdentity identity) => Set<TIdentity>().Remove(identity);

    void IObjectContext.Commit() => SaveChanges();

    Task IObjectContext.CommitAsync() => SaveChangesAsync();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}