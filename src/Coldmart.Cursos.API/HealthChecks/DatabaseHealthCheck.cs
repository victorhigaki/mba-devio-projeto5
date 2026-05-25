using Coldmart.Cursos.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Coldmart.Cursos.API.HealthChecks;

public class DatabaseHealthCheck : IHealthCheck
{
    private readonly ICursosDbContext _dbContext;

    public DatabaseHealthCheck(ICursosDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        if (!await _dbContext.Database.CanConnectAsync(cancellationToken))
        {
            return new HealthCheckResult(context.Registration.FailureStatus, "Unhealthy");
        }

        if (!await _dbContext.Aulas.AnyAsync(cancellationToken))
        {
            return new HealthCheckResult(context.Registration.FailureStatus, "Unhealthy");
        }

        return HealthCheckResult.Healthy("Healthy");
    }
}
