using Coldmart.BFF.ViewModels;
using Coldmart.Core.Communication;

namespace Coldmart.BFF.Services.Interfaces;

public interface ICursoService
{
    Task<ResponseResult?> CriarCursoAsync(CursoViewModel curso);
    Task<ResponseResult?> AdicionarAulaAsync(AulaViewModel viewModel);
    Task<IEnumerable<CursoViewModel>?> ObterTodos();
    Task<CursoViewModel?> ObterPorId(Guid id);
    Task<ResponseResult?> EditarCursoAsync(CursoViewModel viewModel);
}
