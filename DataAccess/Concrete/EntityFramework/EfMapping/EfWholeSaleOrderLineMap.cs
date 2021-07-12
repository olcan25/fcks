using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.EfMapping
{
    public class EfWholeSaleOrderLineMap : BaseEntityMap<WholeSaleOrderLine>
    {
        public override void Configure(EntityTypeBuilder<WholeSaleOrderLine> builder)
        {
            base.Configure(builder);

            builder.ToTable("WholeSaleOrderLines", "Sales");

            builder.HasKey(w => w.Id);

            builder.Property(w => w.Quantity).HasColumnType("decimal");

            builder.Property(w => w.DiscountRate).HasColumnType("smallmoney");

            //Unit Price Data Types

            builder.Property(w => w.UnitPrice).HasColumnType("money");

            builder.Property(w => w.DiscountUnitPrice).HasColumnType("money");

            builder.Property(w => w.VatUnitPrice).HasColumnType("money");

            builder.Property(w => w.UnitPriceWithVat).HasColumnType("money");

            //Amount Data Types

            builder.Property(w => w.Amount).HasColumnType("money");

            builder.Property(w => w.DiscountAmount).HasColumnType("money");

            builder.Property(w => w.VatAmount).HasColumnType("money");

            builder.Property(w => w.AmountWithVat).HasColumnType("money");


            builder.HasOne(w => w.Product)
                .WithMany(w => w.WholeSaleOrderLines)
                .HasForeignKey(w => w.ProductId)
                .IsRequired();

            builder.HasOne(w => w.Vat)
                .WithMany(w => w.WholeSaleOrderLines)
                .HasForeignKey(w => w.VatId)
                .IsRequired();

            builder.HasOne(w => w.Warehouse)
                .WithMany(w => w.WholeSaleOrderLines)
                .HasForeignKey(w => w.WarehouseId)
                .IsRequired(false);

            builder.HasOne(w => w.WholeSaleOrder)
                .WithMany(w => w.WholeSaleOrderLines)
                .HasForeignKey(w => w.WholeSaleOrderId);
        }
    }
}
