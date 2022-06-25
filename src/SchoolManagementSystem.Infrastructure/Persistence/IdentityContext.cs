
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SchoolManagementSystem.Infrastructure.Persistence;

public class IdentityContext : IdentityDbContext<IdentityUser>
{
    public IdentityContext (DbContextOptions<IdentityContext> options)
        : base(options)
    {        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
