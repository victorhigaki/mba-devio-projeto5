using Coldmart.Alunos.Business.Requests;
using Coldmart.Alunos.Business.Services;
using Coldmart.Alunos.Business.ViewModels;
using Coldmart.Core.Controllers;
using Coldmart.Core.Notificacao;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coldmart.Alunos.API.Controllers;

[ApiController, Authorize]
[Route("api/[controller]")]
public class AlunosController : CustomControllerBase
{
    private readonly IMediator _mediator;
    private readonly IAlunoQueries _alunoQueries;

    public AlunosController(IMediator mediator, INotificador notificador, IAlunoQueries alunoQueries)
        : base(notificador)
    {
        _mediator = mediator;
        _alunoQueries = alunoQueries;
    }

    [HttpPost("cursos")]
    public async Task<IActionResult> MatricularAoCurso([FromBody] MatriculaViewModel viewModel)
    {
        await _mediator.Send(new MatricularAoCursoRequest
        {
            Matricula = viewModel
        }, HttpContext.RequestAborted);

        return CustomResponse();
    }

    [HttpPut("cursos/aulas")]
    public async Task<IActionResult> RealizarAula([FromBody] RealizarAulaViewModel viewModel)
    {
        await _mediator.Send(new RealizarAulaRequest
        {
            Aula = viewModel
        }, HttpContext.RequestAborted);

        return CustomResponse();
    }

    [HttpGet("historico")]
    public async Task<IActionResult> Historico()
    {
        var response = await _alunoQueries.Historico();
        return CustomResponse(response);
    }

    [HttpPost("finalizar")]
    public async Task<IActionResult> Finalizar([FromBody] FinalizarViewModel viewModel)
    {
        await _mediator.Send(new FinalizarRequest
        {
            Matricula = viewModel
        }, HttpContext.RequestAborted);
        return CustomResponse();
    }

    [HttpGet("certificado/{id}")]
    public async Task<IActionResult> Certificado(Guid id)
    {
        var response = await _alunoQueries.Certificado(id);
        return CustomResponse(response);
    }
}