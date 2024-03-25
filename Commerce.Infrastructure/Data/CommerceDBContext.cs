using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Infrastructure.Data
{
    public class CommerceDBContext : DbContext
    {
        public CommerceDBContext(DbContextOptions<CommerceDBContext> options)
            : base(options)
        {
        }

        public DbSet<Commerce.Domain.Produto> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commerce.Domain.Produto>(entity =>
            {
                entity.ToTable("PRODUTO");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Nome).HasColumnName("NOME").IsRequired();
                entity.Property(e => e.Valor).HasColumnName("VALOR").IsRequired();
                entity.Property(e => e.Estoque).HasColumnName("ESTOQUE").IsRequired();
            });
        }
    }
}
