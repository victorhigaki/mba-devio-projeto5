using Coldmart.Alunos.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Coldmart.Alunos.API.HealthChecks;

public class DatabaseHealthCheck : IHealthCheck
{
    private readonly IAlunosDbContext _dbContext;

    public DatabaseHealthCheck(IAlunosDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        if (!await _dbContext.Database.CanConnectAsync(cancellationToken))
        {
            return new HealthCheckResult(context.Registration.FailureStatus, "Unhealthy");
        }

        if (!await _dbContext.Alunos.AnyAsync(cancellationToken))
        {
            return new HealthCheckResult(context.Registration.FailureStatus, "Unhealthy");
        }

        return HealthCheckResult.Healthy("Healthy");
    }
}
