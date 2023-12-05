using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Infra.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.PictureUrl)
                .IsRequired();

            builder.HasOne(b => b.ProductBrand)
                .WithMany()
                .HasForeignKey(p => p.ProductBrandId);

            builder.HasOne(b => b.ProductType)
                .WithMany()
                .HasForeignKey(p => p.ProductTypeId);
        }
    }
}
