using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.EfMapping
{
    public class EfPurchaseOrderLineMap : BaseEntityMap<PurchaseOrderLine>
    {
        public override void Configure(EntityTypeBuilder<PurchaseOrderLine> builder)
        {
            base.Configure(builder);

            builder.ToTable("PurchaseOrderLines", "Purchases");

            builder.Property(p => p.Quantity).HasColumnType("decimal");

            //Rate Data Types

            builder.Property(p => p.DiscountRate).HasColumnType("smallmoney");

            builder.Property(p => p.CustomsTaxRate).HasColumnType("smallmoney");

            //builder.Property(p => p.ExciseTaxRate).HasColumnType("smallmoney");


            //UnitPrice Data Types

            builder.Property(p => p.UnitPrice).HasColumnType("money");

            builder.Property(p => p.DiscountUnitPrice).HasColumnType("money");

            builder.Property(p => p.VatUnitPrice).HasColumnType("money");

            builder.Property(p => p.CustomsTaxUnitPrice).HasColumnType("money");

            builder.Property(p => p.ExciseTaxUnitPrice).HasColumnType("money");

            builder.Property(p => p.TransporterUnitPrice).HasColumnType("money");

            builder.Property(x => x.ReEvaluationUnitPrice).HasColumnType("money");

            builder.Property(p => p.GrossWithOutVatUnitPrice).HasColumnType("money");

            builder.Property(p => p.GrossUnitPrice).HasColumnType("money");

            //Amount Types

            builder.Property(p => p.Amount).HasColumnType("money");

            builder.Property(p => p.DiscountAmount).HasColumnType("money");

            builder.Property(p => p.VatAmount).HasColumnType("money");

            builder.Property(p => p.CustomsTaxAmount).HasColumnType("money");

            builder.Property(p => p.ExciseTaxAmount).HasColumnType("money");

            builder.Property(p => p.TransporterAmount).HasColumnType("money");

            builder.Property(p => p.ReEvaluationAmount).HasColumnType("money");

            builder.Property(p => p.GrossWithOutVatAmount).HasColumnType("money");

            builder.Property(p => p.GrossAmount).HasColumnType("money");



            builder.HasOne(p => p.Vat)
                .WithMany(p => p.PurchaseOrderLines)
                .HasForeignKey(p => p.VatId);
            //.IsRequired();

            builder.HasOne(p => p.Product)
                .WithMany(p => p.PurchaseOrderLines)
                .HasForeignKey(p => p.ProductId)
                .IsRequired();

            builder.HasOne(p => p.Warehouse)
                .WithMany(p => p.PurchaseOrderLines)
                .HasForeignKey(p => p.WarehouseId)
                .IsRequired();

            builder.HasOne(p => p.PurchaseOrder)
                .WithMany(p => p.PurchaseOrderLines)
                .HasForeignKey(p => p.PurchaseOrderId);
        }
    }
}
