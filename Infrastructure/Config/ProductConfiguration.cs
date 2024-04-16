using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x=>x.Id).IsRequired();
            builder.Property(x=>x.ProductName).IsRequired().HasMaxLength(100);
            builder.Property(x=>x.Description).IsRequired().HasMaxLength(250);
            builder.Property(x=>x.Price).HasColumnType("decimal(18,2)");
            builder.Property(x=>x.PictureUrl).IsRequired();
            builder.HasOne(b=>b.ProductBrand).WithMany()
            .HasForeignKey(p=>p.ProductBrandId);
            builder.HasOne(b=>b.ProductType).WithMany()
            .HasForeignKey(p=>p.ProductTypeId);
        }
    }
}