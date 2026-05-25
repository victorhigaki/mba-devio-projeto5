using Coldmart.Cursos.Business.ViewModels;

namespace Coldmart.Cursos.Business.Services
{
    public interface ICursoQueries
    {
        Task<CursoViewModel> ObterPorId(Guid id);
        Task<IEnumerable<CursoViewModel>> ObterTodos();
    }
}