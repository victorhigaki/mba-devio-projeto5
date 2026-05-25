using Coldmart.Auth.Business.Services;
using Coldmart.Auth.Business.ViewModels;
using Coldmart.Core.Controllers;
using Coldmart.Core.Notificacao;
using Microsoft.AspNetCore.Mvc;

namespace Coldmart.Auth.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : CustomControllerBase
{
    private readonly IAutenticacaoService _autenticacaoService;

    public AuthController(IAutenticacaoService autenticacaoService, INotificador notificador)
        : base(notificador)
    {
        _autenticacaoService = autenticacaoService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Logar([FromBody] LogarViewModel viewModel)
    {
        var token = await _autenticacaoService.GerarTokenAsync(viewModel);
        return CustomResponse(new { AccessToken = token });
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarViewModel viewModel)
    {
        var token = await _autenticacaoService.CadastrarAsync(viewModel);
        return CustomResponse(new { AccessToken = token });
    }
}
