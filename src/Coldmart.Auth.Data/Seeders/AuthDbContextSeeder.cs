using System.Diagnostics.CodeAnalysis;
using Coldmart.Core.Constants;
using Coldmart.Auth.Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Coldmart.Core.Data.Seeders;

namespace Coldmart.Auth.Data.Seeders;

[ExcludeFromCodeCoverage]
public class AuthDbContextSeeder : IDbContextSeeder
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IAuthDbContext _coreDbContext;

    public AuthDbContextSeeder(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IAuthDbContext coreDbContext)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _coreDbContext = coreDbContext;
    }

    public async Task SeedAsync(CancellationToken cancellationToken)
    {
        if (await _coreDbContext.Users.AnyAsync(cancellationToken))
            return;

        await _roleManager.CreateAsync(new IdentityRole(RolesConstants.Admin));
        await _roleManager.CreateAsync(new IdentityRole(RolesConstants.Aluno));

        var usuarioAdmin = new IdentityUser("admin@coldmart.com")
        {
            Id = "8fb2d600-c625-4c08-9612-24eb199f24da",
            UserName = "admin@coldmart.com",
            Email = "admin@coldmart.com",
        };

        await _userManager.CreateAsync(usuarioAdmin, "Admin@123");
        await _userManager.AddToRoleAsync(usuarioAdmin, RolesConstants.Admin);

        var usuario = new IdentityUser("aluno@coldmart.com")
        {
            Id = "10890b08-2e51-43d0-84d2-244041b6c10c",
            UserName = "aluno@coldmart.com",
            Email = "aluno@coldmart.com",
        };

        await _userManager.CreateAsync(usuario, "Aluno@123");
        await _userManager.AddToRoleAsync(usuario, RolesConstants.Aluno);
    }
}
