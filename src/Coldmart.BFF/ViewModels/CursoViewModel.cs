using System.Diagnostics.CodeAnalysis;

namespace Coldmart.BFF.ViewModels;

[ExcludeFromCodeCoverage]
public sealed class CursoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public List<ConteudoProgramaticoViewModel> ConteudosProgramaticos { get; set; }
}
