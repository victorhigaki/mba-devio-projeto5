using Coldmart.Pagamentos.Business.ViewModels;
using Coldmart.Pagamentos.Domain;

namespace Coldmart.Pagamentos.Business.Extensions;

public static class PagamentoExtension
{
    public static PagamentoViewModel ToViewModel(this Pagamento pagamento)
    {
        return new PagamentoViewModel
        {
            Id = pagamento.Id,
            Cartao = new DadosCartaoViewModel
            {
                NumeroCartao = pagamento.Cartao.NumeroCartao,
                NomeTitular = pagamento.Cartao.NomeTitular,
                DataValidade = pagamento.Cartao.DataValidade,
                CodigoSeguranca = pagamento.Cartao.CodigoSeguranca
            },
            MatriculaId = pagamento.MatriculaId,
            Valor = pagamento.Valor
        };
    }

    public static IEnumerable<PagamentoViewModel> ToViewModel(this IEnumerable<Pagamento> pagamentos)
    {
        return pagamentos.Select(p => ToViewModel(p));
    }
}
