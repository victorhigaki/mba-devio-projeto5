using System.Diagnostics.CodeAnalysis;
using Coldmart.Alunos.Domain;
using Coldmart.Core.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coldmart.Alunos.Data.Configurations;

[ExcludeFromCodeCoverage]
internal sealed class CursoConfiguration : EntityTypeConfiguration<Curso>
{
    public override string TableName => "Curso";

    public override void ConfigureEntity(EntityTypeBuilder<Curso> builder)
    {
        builder
            .Property(c => c.Id)
            .IsRequired();

        builder
            .HasMany(c => c.Aulas)
            .WithOne(a => a.Curso)
            .HasForeignKey(a => a.CursoId);
    }
}
