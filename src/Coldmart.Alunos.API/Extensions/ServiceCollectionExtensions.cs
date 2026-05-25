using Coldmart.Alunos.API.Consumers;
using Coldmart.Alunos.Business.Services;
using Coldmart.Alunos.Data.Extensions;
using Coldmart.Core.Extensions;
using MassTransit;
using System.Diagnostics.CodeAnalysis;

namespace Coldmart.Alunos.API.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigurarInjecaoDependencia(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        services
            .AddAlunosData(configuration, environment);

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<AlunosService>();
        });

        services.AddMassTransit(x =>
        {
            x.AddConsumersFromNamespaceContaining<PagamentoRealizadoConsumer>();

            x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("alunos", false));

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
