
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.Infrastructure.Repositories.Identity;

public class UserManagerRepository : IUserManagerRepository
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserManagerRepository(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> AddToRole(IdentityUser user, string role)
        => await _userManager.AddToRoleAsync(user,role);

    public async Task<bool> CheckPassword(IdentityUser user, string password)
        => await _userManager.CheckPasswordAsync(user, password);

    public async Task<IdentityResult> Create(IdentityUser user, string password)
        => await _userManager.CreateAsync(user, password);

    public async Task<IdentityUser> FindByName(string username)
        => await _userManager.FindByNameAsync(username);

    public async Task<IList<string>> GetRoles(IdentityUser user)
        => await _userManager.GetRolesAsync(user);
}