using System.Diagnostics.CodeAnalysis;
using Coldmart.BFF.Models;
using Coldmart.BFF.Services.Interfaces;
using Coldmart.BFF.ViewModels;
using Microsoft.Extensions.Options;

namespace Coldmart.BFF.Services;

[ExcludeFromCodeCoverage]
public class AuthService : Service, IAuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(settings.Value.AuthServiceUrl);
    }

    public async Task<AccessTokenResponseViewModel?> Cadastro(CadastrarViewModel viewModel)
    {
        var authContent = ObterConteudo(viewModel);
        var response = await _httpClient.PostAsync("api/auth/cadastro", authContent);
        var result = await DeserializarObjetoResponse<AccessTokenResponseViewModel>(response);
        return result;
    }

    public async Task<AccessTokenResponseViewModel?> Logar(LogarViewModel viewModel)
    {
        var authContent = ObterConteudo(viewModel);
        var response = await _httpClient.PostAsync("api/auth/login", authContent);
        var result = await DeserializarObjetoResponse<AccessTokenResponseViewModel>(response);
        return result;
    }
}
