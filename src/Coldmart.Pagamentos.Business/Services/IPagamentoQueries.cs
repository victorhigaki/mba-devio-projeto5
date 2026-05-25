using Coldmart.Pagamentos.Business.ViewModels;

namespace Coldmart.Pagamentos.Business.Services;

public interface IPagamentoQueries
{
    Task<IEnumerable<PagamentoViewModel>> ObterTodosAsync();
    Task<PagamentoViewModel> ObterPorIdAsync(Guid id);
}