using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Coldmart.BFF.ViewModels;

[ExcludeFromCodeCoverage]
public class AlterarStatusPagamentoViewModel
{
    [Required]
    public Guid PagamentoId { get; set; }
}