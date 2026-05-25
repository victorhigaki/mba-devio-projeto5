using System.Diagnostics.CodeAnalysis;
using Coldmart.Alunos.Data.Contexts;
using Coldmart.Alunos.Data.Seeders;
using Coldmart.Core.Data.Extensions;
using Coldmart.Core.Data.Seeders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Coldmart.Alunos.Data.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAlunosData(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        services.AddDbContext<IAlunosDbContext, AlunosDbContext>(options =>
        {
            options.ConfigureDbContextOptions(configuration, environment);
        });

        services.AddScoped<IDbSeeder, DbSeeder>();
        services.AddScoped<IDbContextSeeder, AlunosDbContextSeeder>();

        return services;
    }
}
