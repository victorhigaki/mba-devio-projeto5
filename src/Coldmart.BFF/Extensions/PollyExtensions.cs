using System.Diagnostics.CodeAnalysis;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

namespace Coldmart.BFF.Extensions;

[ExcludeFromCodeCoverage]
public static class PollyExtensions
{
    public static AsyncRetryPolicy<HttpResponseMessage> EsperarTentar()
    {
        var retry = HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(new[]
            {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(10),
            });

        return retry;
    }
}
