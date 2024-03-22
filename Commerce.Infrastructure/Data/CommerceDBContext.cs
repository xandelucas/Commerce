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
    }
}
