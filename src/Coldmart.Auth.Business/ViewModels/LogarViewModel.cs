using System.ComponentModel.DataAnnotations;
using Coldmart.Auth.Business.Attributes;

namespace Coldmart.Auth.Business.ViewModels;

public class LogarViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [SenhaRegularExpression]
    public string Senha { get; set; }
}
