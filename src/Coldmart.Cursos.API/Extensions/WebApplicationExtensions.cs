using Coldmart.Core.Data.Seeders;
using Coldmart.Cursos.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Coldmart.Cursos.API.Extensions;

public static class WebApplicationExtensions
{
    public static async Task<WebApplication> AplicarMigracoesAsync(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();

        var cursosDbContext = scope.ServiceProvider.GetRequiredService<ICursosDbContext>();
        await cursosDbContext.Database.MigrateAsync(CancellationToken.None);

        return app;
    }

    public static async Task SeedBancoDeDadosAsync(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();

        var seeder = scope.ServiceProvider.GetRequiredService<IDbSeeder>();

        await seeder.SeedAsync(CancellationToken.None);
    }
}