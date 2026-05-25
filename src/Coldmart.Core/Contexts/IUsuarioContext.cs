using Microsoft.AspNetCore.Http;

namespace Coldmart.Core.Contexts;

public interface IUsuarioContext
{
    Guid? ObterIdUsuario();
    string ObterEmailUsuario();
    HttpContext ObterHttpContext();
    string ObterUserToken();
}
