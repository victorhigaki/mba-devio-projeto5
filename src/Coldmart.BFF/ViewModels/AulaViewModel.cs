using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Coldmart.BFF.ViewModels;

[ExcludeFromCodeCoverage]
public sealed class AulaViewModel
{
    [Required]
    [Length(2, 60)]
    public string Titulo { get; set; }

    [Required]
    [Range(10, 1800)]
    public int DuracaoSegundos { get; set; }

    [Required]
    public Guid CursoId { get; set; }
}