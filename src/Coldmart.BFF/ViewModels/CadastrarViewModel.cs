using System.Diagnostics.CodeAnalysis;

namespace Coldmart.BFF.ViewModels;

[ExcludeFromCodeCoverage]
public class CadastrarViewModel
{
    public string Email { get; set; }
    public string Senha { get; set; }
    public string ConfirmarSenha { get; set; }
}
