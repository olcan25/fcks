using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.EfMapping
{
    public class EfLedgerMap : BaseEntityMap<Ledger>
    {
        public override void Configure(EntityTypeBuilder<Ledger> builder)
        {
            base.Configure(builder);

            builder.ToTable("Ledgers", "Accounting");

            builder.HasKey(x => x.Id);

            builder.Property(l => l.Description).HasMaxLength(500);

            builder.HasMany(l => l.WholeSaleOrders)
                .WithOne(l => l.Ledger)
                .HasForeignKey(l => l.LedgerId);

            builder.HasMany(l => l.PurchaseOrders)
                .WithOne(l => l.Ledger)
                .HasForeignKey(l => l.LedgerId);

            builder.HasMany(l => l.Payments)
                .WithOne(l => l.Ledger)
                .HasForeignKey(l => l.LedgerId);

            builder.HasMany(l => l.LedgerEntries)
                .WithOne(l => l.Ledger)
                .HasForeignKey(l => l.LedgerId);
        }
    }
}
