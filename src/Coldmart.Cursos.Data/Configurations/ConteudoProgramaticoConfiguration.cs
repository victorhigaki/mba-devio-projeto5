using System.Diagnostics.CodeAnalysis;
using Coldmart.Core.Data.Configurations;
using Coldmart.Cursos.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coldmart.Cursos.Data.Configurations;

[ExcludeFromCodeCoverage]
internal sealed class ConteudoProgramaticoConfiguration : EntityTypeConfiguration<ConteudoProgramatico>
{
    public override string TableName => "ConteudoProgramatico";

    public override void ConfigureEntity(EntityTypeBuilder<ConteudoProgramatico> builder)
    {
        builder
            .Property(cp => cp.Titulo)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(cp => cp.Descricao)
            .IsRequired()
            .HasMaxLength(100);
    }
}
