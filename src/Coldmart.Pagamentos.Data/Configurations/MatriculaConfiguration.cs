using System.Diagnostics.CodeAnalysis;
using Coldmart.Core.Data.Configurations;
using Coldmart.Pagamentos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coldmart.Pagamentos.Data.Configurations;

[ExcludeFromCodeCoverage]
internal sealed class MatriculaConfiguration : EntityTypeConfiguration<Matricula>
{
    public override string TableName => "Matricula";

    public override void ConfigureEntity(EntityTypeBuilder<Matricula> builder)
    {
        builder
            .Property(a => a.Id)
            .IsRequired();
    }
}