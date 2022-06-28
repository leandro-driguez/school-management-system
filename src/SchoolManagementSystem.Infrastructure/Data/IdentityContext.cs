
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SchoolManagementSystem.Infrastructure.Data;

public class IdentityContext : IdentityDbContext<IdentityUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        this.SeedUsers(builder);  
        this.SeedRoles(builder);  
        this.SeedUserRoles(builder);  
    }  

    private void SeedUsers(ModelBuilder builder)  
    {  
        PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();  
        
        IdentityUser user = new IdentityUser()  
        {  
            Id = "8ae7e3b7-0e7a-46c0-957b-394f5a92d858",  
            UserName = "admin",  
            NormalizedUserName = "ADMIN",
            Email = "admin@dclase.com",  
            NormalizedEmail = "ADMIN@DCLASE.COM",
            PhoneNumber = "53452234",
            PasswordHash = "AQAAAAEAACcQAAAAED6EqU3WQKJxv+GJfszYJdHbsQSlqPzreV2lF4+6PVGJTtp2SslUfNnoL/mVCc//0A==",
            SecurityStamp = "QLJLDMNXCTJPGIQYC2Z4UNLIJQHAAUNP",
            ConcurrencyStamp = "a0cc035a-39f4-477b-98d7-28a137aef4f8",
            LockoutEnabled = true,  
        };

        builder.Entity<IdentityUser>().HasData(user);  
    }  

    private void SeedRoles(ModelBuilder builder)  
    {  
        builder.Entity<IdentityRole>().HasData(  
            new IdentityRole() { 
                Id = "da9533ca-0804-4557-abc8-046e05514ae0", 
                Name = "Admin",   
                NormalizedName = "ADMIN", 
                ConcurrencyStamp = "0e20d00d-817a-4d93-a9f7-6bc60eeee6c9"
            },
            new IdentityRole() { 
                Id = "d39c3aa3-4cce-45e5-9fe6-69c071ee6758", 
                Name = "User",   
                NormalizedName = "USER", 
                ConcurrencyStamp = "4708f4c2-2a06-4c5b-adbc-3d38ccc5e60a"
            }     
        );  
    }  

    private void SeedUserRoles(ModelBuilder builder)  
    {  
        builder.Entity<IdentityUserRole<string>>().HasData(  
            new IdentityUserRole<string>() { 
                UserId = "8ae7e3b7-0e7a-46c0-957b-394f5a92d858",
                RoleId = "da9533ca-0804-4557-abc8-046e05514ae0"
            },
            new IdentityUserRole<string>() { 
                UserId = "8ae7e3b7-0e7a-46c0-957b-394f5a92d858",
                RoleId = "d39c3aa3-4cce-45e5-9fe6-69c071ee6758"
            }  
        );  
    }  
}
