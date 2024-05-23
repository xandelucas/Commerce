using Commerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Commerce.Infrastructure.Configurations;

internal class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("PRODUTO");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id);
        builder.Property(e => e.Nome).HasMaxLength(64);
        builder.Property(e => e.Valor).HasPrecision(14, 3);
        builder.Property(e => e.Estoque);
        builder.Property(e => e.DataCadastroUtc);
        builder.Property(e => e.Status);
        builder.Property(e => e.DataAtualizacaoUtc);
        builder.Property(e => e.CategoriaId);

        builder
            .HasOne<Categoria>()
            .WithMany()
            .HasForeignKey(c => c.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
