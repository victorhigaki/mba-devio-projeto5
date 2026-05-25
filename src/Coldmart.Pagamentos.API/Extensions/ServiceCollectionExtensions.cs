using System.Diagnostics.CodeAnalysis;
using Coldmart.Core.Extensions;
using Coldmart.Pagamentos.Business.Services;
using Coldmart.Pagamentos.Data.Extensions;
using MassTransit;

namespace Coldmart.Pagamentos.API.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigurarInjecaoDependencia(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        services
            .AddPagamentosData(configuration, environment);

        services.AddScoped<IPagamentoQueries, PagamentoQueries>();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<PagamentosService>();
        });

        services.AddMassTransit(x =>
        {
            x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("pagamentos", false));

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration["RabbitMq:Host"], "/", h =>
                {
                    h.Username(configuration.GetValue("RabbitMq:Username", "coldmart"));
                    h.Password(configuration.GetValue("RabbitMq:Password", "coldmart"));
                });
                cfg.ConfigureEndpoints(context);
            });
        });


        services
            .AddCoreServices(configuration);

        return services;
    }
}
