using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.EfMapping
{
    public class EfWholeSaleOrderMap : BaseEntityMap<WholeSaleOrder>
    {
        public override void Configure(EntityTypeBuilder<WholeSaleOrder> builder)
        {
            base.Configure(builder);

            builder.ToTable("WholeSaleOrders", "Sales");


            builder.HasOne(w => w.Partner)
                .WithMany(w => w.WholeSaleOrders)
                .HasForeignKey(w => w.PartnerId);

            builder.HasOne(w => w.Ledger)
                .WithMany(w => w.WholeSaleOrders)
                .HasForeignKey(w => w.LedgerId);

            builder.HasMany(x => x.WholeSaleOrderLines)
                .WithOne(x => x.WholeSaleOrder)
                .HasForeignKey(x => x.WholeSaleOrderId);
        }
    }
}
