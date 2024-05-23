using Microsoft.EntityFrameworkCore;
using Commerce.Infrastructure.Configurations;
using Commerce.Domain;

namespace Commerce.Infrastructure.Data;

public class CommerceDBContext : DbContext
{
    public CommerceDBContext(DbContextOptions<CommerceDBContext> options)
        : base(options)
    {
    }

    public DbSet<Produto> Produto => Set<Produto>();
    public DbSet<Categoria> Categorias => Set<Categoria>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration ( new CategoriaConfiguration() );
        modelBuilder.ApplyConfiguration( new ProdutoConfiguration() );
    }
}
