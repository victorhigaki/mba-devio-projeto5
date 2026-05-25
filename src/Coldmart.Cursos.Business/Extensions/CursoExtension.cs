using Coldmart.Cursos.Business.ViewModels;
using Coldmart.Cursos.Domain;

namespace Coldmart.Cursos.Business.Extensions
{
    public static class CursoExtension
    {
        public static CursoViewModel ToViewModel(this Curso curso)
        {
            return new CursoViewModel
            {
                Id = curso.Id,
                Nome = curso.Nome,
                ConteudosProgramaticos = curso.ConteudosProgramaticos?.Select(cp => new ConteudoProgramaticoViewModel
                {
                    Titulo = cp.Titulo,
                    Descricao = cp.Descricao
                })?.ToList()
            };
        }

        public static IEnumerable<CursoViewModel> ToViewModel(this IEnumerable<Curso> cursos)
        {
            return cursos.Select(curso => curso.ToViewModel()).ToList();
        }
    }
}
