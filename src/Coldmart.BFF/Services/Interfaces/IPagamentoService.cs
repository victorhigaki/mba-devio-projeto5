using Coldmart.BFF.ViewModels;
using Coldmart.Core.Communication;

namespace Coldmart.BFF.Services.Interfaces;

public interface IPagamentoService
{
    Task<PagamentoViewModel?> ObterPorIdAsync(Guid id);
    Task<IEnumerable<PagamentoViewModel>?> ObterTodosAsync();
    Task<ResponseResult?> CriarPagamentoAsync(PagamentoViewModel pagamento);
    Task<ResponseResult?> AprovarPagamentoAsync(Guid id);
    Task<ResponseResult?> CancelarPagamentoAsync(Guid id);
}
