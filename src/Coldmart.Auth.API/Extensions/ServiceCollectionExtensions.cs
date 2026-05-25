using System.Diagnostics.CodeAnalysis;
using Coldmart.Auth.Business.Services;
using Coldmart.Auth.Data.Extensions;
using Coldmart.Core.Extensions;

namespace Coldmart.Auth.API.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigurarInjecaoDependencia(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        services
            .AddAuthData(configuration, environment);

        services
            .AddCoreServices(configuration)
            .AddAuthSeeder();

        services.AddScoped<IAutenticacaoService, AutenticacaoService>();

        return services;
    }
}
