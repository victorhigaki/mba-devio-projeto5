using Coldmart.Auth.Business.ViewModels;

namespace Coldmart.Auth.Business.Services;

public interface IAutenticacaoService
{
    Task<string> GerarTokenAsync(LogarViewModel inputModel);
    Task<string> CadastrarAsync(CadastrarViewModel inputModel);
}
