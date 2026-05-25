using Coldmart.Core.Data.Seeders;
using Coldmart.Pagamentos.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Coldmart.Pagamentos.API.Extensions;

public static class WebApplicationExtensions
{
    public static async Task<WebApplication> AplicarMigracoesAsync(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();

        var pagamentosDbContext = scope.ServiceProvider.GetRequiredService<IPagamentosDbContext>();
        await pagamentosDbContext.Database.MigrateAsync(CancellationToken.None);

        return app;
    }

    public static async Task SeedBancoDeDadosAsync(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();

        var seeder = scope.ServiceProvider.GetRequiredService<IDbSeeder>();

        await seeder.SeedAsync(CancellationToken.None);
    }
}