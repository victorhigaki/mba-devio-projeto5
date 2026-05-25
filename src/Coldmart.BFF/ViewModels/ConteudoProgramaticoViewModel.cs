using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Coldmart.BFF.ViewModels;

[ExcludeFromCodeCoverage]
public sealed class ConteudoProgramaticoViewModel
{
    [Required]
    [Length(3, 50)]
    public string Titulo { get; set; }

    [Required]
    [Length(5, 100)]
    public string Descricao { get; set; }
}