using Coldmart.Cursos.Business.Extensions;
using Coldmart.Cursos.Business.ViewModels;
using Coldmart.Cursos.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Coldmart.Cursos.Business.Services;

public class CursoQueries : ICursoQueries
{
    private readonly ICursosDbContext _cursosDbContext;

    public CursoQueries(ICursosDbContext cursosDbContext)
    {
        _cursosDbContext = cursosDbContext;
    }

    public async Task<IEnumerable<CursoViewModel>> ObterTodos()
    {
        var cursos = await _cursosDbContext.Cursos.ToListAsync();
        return cursos.ToViewModel();
    }

    public async Task<CursoViewModel> ObterPorId(Guid id)
    {
        var curso = await _cursosDbContext.Cursos.FindAsync(id);
        if (curso == null) return null;
        return curso.ToViewModel();
    }
}
