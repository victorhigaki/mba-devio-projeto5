using System.Diagnostics.CodeAnalysis;
using Coldmart.Alunos.Domain;
using Coldmart.Core.Data.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coldmart.Alunos.Data.Configurations;

[ExcludeFromCodeCoverage]
internal sealed class AulaConfiguration : EntityTypeConfiguration<Aula>
{
    public override string TableName => "Aula";

    public override void ConfigureEntity(EntityTypeBuilder<Aula> builder)
    {
        builder
            .Property(a => a.Id)
            .IsRequired();

        builder
            .Property(a => a.CursoId)
            .IsRequired();
    }
}
