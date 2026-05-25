using System.Diagnostics.CodeAnalysis;
using Coldmart.BFF.Models;
using Coldmart.BFF.Services.Interfaces;
using Coldmart.BFF.ViewModels;
using Coldmart.Core.Communication;
using Microsoft.Extensions.Options;

namespace Coldmart.BFF.Services;

[ExcludeFromCodeCoverage]
public class CursoService : Service, ICursoService
{
    private readonly HttpClient _httpClient;

    public CursoService(HttpClient httpClient, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(settings.Value.CursosServiceUrl);
    }

    public async Task<ResponseResult?> CriarCursoAsync(CursoViewModel curso)
    {
        var cursoContent = ObterConteudo(curso);
        var response = await _httpClient.PostAsync("api/cursos", cursoContent);
        return await DeserializarObjetoResponse<ResponseResult>(response);
    }

    public async Task<ResponseResult?> AdicionarAulaAsync(AulaViewModel aula)
    {
        var aulaContent = ObterConteudo(aula);
        var response = await _httpClient.PostAsync($"api/cursos/{aula.CursoId}/aulas", aulaContent);
        return await DeserializarObjetoResponse<ResponseResult>(response);
    }

    public async Task<IEnumerable<CursoViewModel>?> ObterTodos()
    {
        var response = await _httpClient.GetAsync("api/cursos");
        return await DeserializarObjetoResponse<IEnumerable<CursoViewModel>>(response);
    }

    public async Task<CursoViewModel?> ObterPorId(Guid id)
    {
        var response = await _httpClient.GetAsync("api/cursos/" + id);
        return await DeserializarObjetoResponse<CursoViewModel>(response);
    }

    public async Task<ResponseResult?> EditarCursoAsync(CursoViewModel viewModel)
    {
        var cursoContent = ObterConteudo(viewModel);
        var response = await _httpClient.PutAsync("api/cursos/" + viewModel.Id, cursoContent);
        return await DeserializarObjetoResponse<ResponseResult>(response);
    }
}
