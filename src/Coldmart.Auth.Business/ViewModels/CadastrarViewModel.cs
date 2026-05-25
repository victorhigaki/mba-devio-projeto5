using System.ComponentModel.DataAnnotations;
using Coldmart.Auth.Business.Attributes;

namespace Coldmart.Auth.Business.ViewModels;

public class CadastrarViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [SenhaRegularExpression]
    public string Senha { get; set; }

    [Required]
    [Compare("Senha", ErrorMessage = "As senhas não coincidem.")]
    public string ConfirmarSenha { get; set; }
}
