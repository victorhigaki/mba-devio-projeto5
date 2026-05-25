using Coldmart.Core.Domain;

namespace Coldmart.Alunos.Domain;

public class Aula : Entity
{
    public Guid CursoId { get; set; }
    public virtual Curso Curso { get; set; }

    public Aula() { }
}