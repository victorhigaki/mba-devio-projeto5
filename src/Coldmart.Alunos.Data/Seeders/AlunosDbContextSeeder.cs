using System.Diagnostics.CodeAnalysis;
using Coldmart.Alunos.Data.Contexts;
using Coldmart.Alunos.Domain;
using Coldmart.Core.Data.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Coldmart.Alunos.Data.Seeders;

[ExcludeFromCodeCoverage]
internal class AlunosDbContextSeeder : IDbContextSeeder
{
    private readonly IAlunosDbContext _alunosDbContext;

    public AlunosDbContextSeeder(IAlunosDbContext alunosDbContext)
    {
        _alunosDbContext = alunosDbContext;
    }

    public async Task SeedAsync(CancellationToken cancellationToken)
    {
        if (await _alunosDbContext.Alunos.AnyAsync(cancellationToken))
            return;

        var curso = new Curso
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            DataCriacao = DateTimeOffset.UtcNow
        };
        await _alunosDbContext.Cursos.AddAsync(curso, cancellationToken);

        var aula = new Aula
        {
            Id = Guid.NewGuid(),
            CursoId = curso.Id,
            DataCriacao = DateTimeOffset.UtcNow
        };
        await _alunosDbContext.Aulas.AddAsync(aula, cancellationToken);

        var aluno = new Aluno(new Guid("10890b08-2e51-43d0-84d2-244041b6c10c"), "aluno@coldmart.com", "aluno@coldmart.com");
        await _alunosDbContext.Alunos.AddAsync(aluno, cancellationToken);

        await _alunosDbContext.SaveChangesAsync(cancellationToken);
    }
}
