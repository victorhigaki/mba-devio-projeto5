using Coldmart.Cursos.Business.ViewModels;
using MediatR;

namespace Coldmart.Cursos.Business.Requests;

public class EditarCursoRequest : IRequest
{
    public required CursoViewModel Curso { get; init; }
}
