using Coldmart.Alunos.Business.ViewModels;
using MediatR;

namespace Coldmart.Alunos.Business.Requests;

public class FinalizarRequest : IRequest
{
    public FinalizarViewModel Matricula { get; set; }
}
