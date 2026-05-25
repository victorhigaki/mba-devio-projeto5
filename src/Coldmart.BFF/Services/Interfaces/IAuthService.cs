using Coldmart.BFF.ViewModels;
using static Coldmart.BFF.Services.AuthService;

namespace Coldmart.BFF.Services.Interfaces;

public interface IAuthService
{
    Task<AccessTokenResponseViewModel?> Cadastro(CadastrarViewModel viewModel);
    Task<AccessTokenResponseViewModel?> Logar(LogarViewModel viewModel);
}
