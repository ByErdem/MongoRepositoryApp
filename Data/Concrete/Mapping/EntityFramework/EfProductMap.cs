using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.Mapping.EntityFramework
{
    public class EfProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.Name).HasMaxLength(250).IsRequired();
            builder.Property(x=>x.Quantity).IsRequired();
            builder.Property(x=>x.Value).IsRequired();
            builder.ToTable("Products");
        }
    }
}
