using Data.Concrete.Mapping.EntityFramework;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.Contexts
{
    public class EfContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
            }

            optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=CRM;Persist Security Info=True;User ID=sa;Password=123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EfProductMap());
        }
    }
}
