
using Microsoft.AspNetCore.Identity;

namespace SchoolManagementSystem.Application.Authenticate.Interfaces;

public interface IUserManagerRepository
{
    Task<IdentityUser> FindByName(string username);
    
    Task<bool> CheckPassword(IdentityUser user, string password);

    Task<IList<string>> GetRoles(IdentityUser user);

    Task<IdentityResult> Create(IdentityUser user, string password);

    Task<IdentityResult> AddToRole(IdentityUser user, string role);
}
