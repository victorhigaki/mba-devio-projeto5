using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Coldmart.Auth.Data.Contexts;

public interface IAuthDbContext
{
    DbSet<IdentityUser> Users { get; }
    DbSet<IdentityRole> Roles { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    DatabaseFacade Database { get; }
}