using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.EfMapping
{
    public class EfVatMap : BaseEntityMap<Vat>
    {
        public override void Configure(EntityTypeBuilder<Vat> builder)
        {
            base.Configure(builder);

            builder.ToTable("Vats", "Products");

            builder.HasKey(x => x.Id);

            builder.Property(v => v.Name).HasMaxLength(30);

            builder.HasMany(v => v.PurchaseOrderLines)
                .WithOne(v => v.Vat)
                .HasForeignKey(v => v.VatId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(v => v.WholeSaleOrderLines)
                .WithOne(v => v.Vat)
                .HasForeignKey(v => v.VatId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(v => v.Products)
                .WithOne(v => v.Vat)
                .HasForeignKey(v => v.VatId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
