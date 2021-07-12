using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.EfMapping
{
    public class EfProductMap : BaseEntityMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.ToTable("Products", "Products");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).HasMaxLength(250);

            builder.Property(p => p.Description).HasMaxLength(250);

            //builder.Property(p => p.DefaultBuyingPrice).HasDefaultValue(0);

            builder.Property(p => p.DefaultBuyingPrice).HasColumnType("money");

            //builder.Property(p => p.DefaultSellingPrice).HasDefaultValue(0);

            builder.Property(p => p.DefaultSellingPrice).HasColumnType("money");

            builder.Property(p => p.ProductTypeId).HasDefaultValue(1);

            builder.Property(p => p.CategoryId).IsRequired(false);

            builder.HasMany(p => p.PurchaseOrderLines)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId);

            builder.HasMany(p => p.WholeSaleOrderLines)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId);

            builder.HasOne(p => p.Vat)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.VatId);

            builder.HasOne(p => p.UnitOfMeasure)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.UnitOfMeasureId);

            builder.HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired(false);

            builder.HasOne(x => x.ProductType)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ProductTypeId);
        }
    }
}
