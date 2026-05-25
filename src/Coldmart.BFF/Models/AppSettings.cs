using System.Diagnostics.CodeAnalysis;

namespace Coldmart.BFF.Models;

[ExcludeFromCodeCoverage]
public class AppSettings
{
    public string CursosServiceUrl { get; set; }
    public string AlunosServiceUrl { get; set; }
    public string PagamentosServiceUrl { get; set; }
    public string AuthServiceUrl { get; set; }
}
