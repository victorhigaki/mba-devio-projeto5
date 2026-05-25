using Coldmart.Core.Domain;

namespace Coldmart.Alunos.Domain;

public class Curso : Entity
{
    public virtual List<Aula> Aulas { get; set; }

    public Curso() { }
}
