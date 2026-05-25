using System.ComponentModel.DataAnnotations;

namespace Coldmart.Cursos.Business.ViewModels;

public sealed class ConteudoProgramaticoViewModel
{
    [Required]
    [Length(3, 50)]
    public string Titulo { get; set; }

    [Required]
    [Length(5, 100)]
    public string Descricao { get; set; }
}