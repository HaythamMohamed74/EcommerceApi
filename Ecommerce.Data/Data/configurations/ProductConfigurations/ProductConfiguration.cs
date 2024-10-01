using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Data.configurations.ProductConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p=>p.Id);
            builder.Property(p => p.Name)
             .IsRequired()
             .HasMaxLength(100);
            builder.Property(p=>p.Id).UseIdentityColumn(1,1);
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDAET()");
            builder.HasQueryFilter( p=>! p.isDeleted);
            builder.HasOne(p => p.Brand)   // Product.Brand
                          .WithMany(b => b.Products)     // A Brand has many Products
                          .HasForeignKey(p => p.BrandId);
            builder.HasOne(p=>p.Type).WithMany(t=>t.Products).HasForeignKey(x=>x.TypeId);
        }
    }
}
