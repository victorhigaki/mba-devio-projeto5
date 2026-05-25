using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using Coldmart.Core.Contexts;

namespace Coldmart.BFF.Extensions
{
    [ExcludeFromCodeCoverage]
    public class HttpClientAuthorizationDelegatingHandler : DelegatingHandler
    {
        private readonly IUsuarioContext _usuarioContext;

        public HttpClientAuthorizationDelegatingHandler(IUsuarioContext aspNetUser)
        {
            _usuarioContext = aspNetUser;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var authorizationHeader = _usuarioContext.ObterHttpContext().Request.Headers["Authorization"];

            if (!string.IsNullOrEmpty(authorizationHeader))
            {
                request.Headers.Add("Authorization", new List<string>() { authorizationHeader! });
            }

            var token = _usuarioContext.ObterUserToken();

            if (token != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
