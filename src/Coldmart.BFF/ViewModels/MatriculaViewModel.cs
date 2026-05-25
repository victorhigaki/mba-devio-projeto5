using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Coldmart.BFF.ViewModels;

[ExcludeFromCodeCoverage]
public class MatriculaViewModel
{
    [Required]
    public Guid CursoId { get; set; }
}
