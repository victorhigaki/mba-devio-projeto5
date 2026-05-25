using System.Diagnostics.CodeAnalysis;

namespace Coldmart.BFF.Services;

[ExcludeFromCodeCoverage]
public class AccessTokenResponseViewModel
{
    public string AccessToken { get; set; }
}
