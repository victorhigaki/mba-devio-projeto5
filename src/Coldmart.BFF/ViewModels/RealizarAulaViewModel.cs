using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Coldmart.BFF.ViewModels;

[ExcludeFromCodeCoverage]
public class RealizarAulaViewModel
{
    [Required]
    public Guid AulaId { get; set; }
}
