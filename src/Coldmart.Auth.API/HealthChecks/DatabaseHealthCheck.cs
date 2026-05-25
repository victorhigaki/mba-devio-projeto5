using Coldmart.Auth.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Coldmart.Auth.API.HealthChecks;

public class DatabaseHealthCheck : IHealthCheck
{
    private readonly IAuthDbContext _dbContext;

    public DatabaseHealthCheck(IAuthDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        if (!await _dbContext.Database.CanConnectAsync(cancellationToken))
        {
            return new HealthCheckResult(context.Registration.FailureStatus, "Unhealthy");
        }

        if (!await _dbContext.Users.AnyAsync(cancellationToken))
        {
            return new HealthCheckResult(context.Registration.FailureStatus, "Unhealthy");
        }

        return HealthCheckResult.Healthy("Healthy");
    }
}
