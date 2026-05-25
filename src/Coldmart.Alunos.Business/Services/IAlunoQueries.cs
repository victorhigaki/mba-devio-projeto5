using Coldmart.Alunos.Domain;

namespace Coldmart.Alunos.Business.Services;

public interface IAlunoQueries
{
    Task<Certificado> Certificado(Guid id);
    Task<IEnumerable<HistoricoAluno>> Historico();
}