using Commerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Commerce.Infrastructure.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("CATEGORIA");

        builder.HasKey(c => c.Id);

        builder.Property(C => C.Nome).HasMaxLength(64);
        builder.Property(C => C.Descricao).HasMaxLength(999);
    }
}
