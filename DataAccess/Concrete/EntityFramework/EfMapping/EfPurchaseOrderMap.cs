using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.EfMapping
{
    public class EfPurchaseOrderMap : BaseEntityMap<PurchaseOrder>
    {
        public override void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            base.Configure(builder);

            builder.ToTable("PurchaseOrders", "Purchases");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.InvoiceNumber).HasMaxLength(30);

            builder.HasMany(p => p.PurchaseOrderLines)
                .WithOne(p => p.PurchaseOrder)
                .HasForeignKey(p => p.PurchaseOrderId);

            builder.HasOne(p => p.Ledger)
                .WithMany(p => p.PurchaseOrders)
                .HasForeignKey(p => p.LedgerId);

            builder.HasOne(x => x.Partner)
                .WithMany(x => x.PartnerPurchaseOrders)
                .HasForeignKey(x => x.PartnerId);

            builder.HasOne(x => x.Transporter)
                .WithMany(x => x.TransporterPurchaseOrders)
                .HasForeignKey(x => x.TransporterId)
                .IsRequired(false);
        }
    }
}
