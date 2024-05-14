using Microsoft.AspNetCore.Identity;

namespace FXAPIV1.Domain.Users;

public class UserCreator
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserCreator(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<(IdentityResult, string)> Create(string email, string password, List<Claim> claims)
    {
        var newUser = new IdentityUser { UserName = email, Email = email };

        var result = await _userManager.CreateAsync(newUser, password);

        if (!result.Succeeded)
            return (result, String.Empty);

        return (await _userManager.AddClaimsAsync(newUser, claims), newUser.Id);
    }

    public async Task<(IdentityResult, string)> CreateMember(string email, string password, List<Claim> claims)
    {

        if (!_roleManager.RoleExistsAsync("Member").Result)
        {
            IdentityRole new_role = new IdentityRole();
            new_role.Name = "Member";
            new_role.NormalizedName = "MEMBER";
            await _roleManager.CreateAsync(new_role);
        }


        var newUser = new IdentityUser { UserName = email, Email = email };
        var result = await _userManager.CreateAsync(newUser, password);
        await _userManager.AddClaimsAsync(newUser, claims);

        if (!result.Succeeded)
            return (result, String.Empty);

        return (await _userManager.AddToRoleAsync(newUser, "Member"), newUser.Id);
    }

    public async Task<(IdentityResult, string)> CreateAdminRoot(string email, string password, List<Claim> claims)
    {

        if (!_roleManager.RoleExistsAsync("Admin").Result)
        {
            IdentityRole new_role = new IdentityRole();
            new_role.Name = "Admin";
            new_role.NormalizedName = "ADMIN";
            await _roleManager.CreateAsync(new_role);
        }


        var newUser = new IdentityUser { UserName = email, Email = email };
        var result = await _userManager.CreateAsync(newUser, password);
        await _userManager.AddClaimsAsync(newUser, claims);

        if (!result.Succeeded)
            return (result, String.Empty);

        return (await _userManager.AddToRoleAsync(newUser, "Admin"), newUser.Id);
    }
}
