using Coldmart.Pagamentos.Data.Contexts;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Coldmart.Pagamentos.API.HealthChecks;

public class DatabaseHealthCheck : IHealthCheck
{
    private readonly IPagamentosDbContext _dbContext;

    public DatabaseHealthCheck(IPagamentosDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        if (!await _dbContext.Database.CanConnectAsync(cancellationToken))
        {
            return new HealthCheckResult(context.Registration.FailureStatus, "Unhealthy");
        }

        return HealthCheckResult.Healthy("Healthy");
    }
}
