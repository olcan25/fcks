using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.EfMapping
{
    public class EfCurrencyMap : BaseEntityMap<Currency>
    {
        public override void Configure(EntityTypeBuilder<Currency> builder)
        {
            base.Configure(builder);

            builder.ToTable("Currencies", "Currencies");

            builder.Property(e => e.Name).HasMaxLength(30);

            builder.Property(e => e.ShortName).HasMaxLength(5);

            builder.Property(e => e.Symbol).HasMaxLength(5);

            builder.HasMany(e => e.Payments)
                .WithOne(e => e.Currency)
                .HasForeignKey(e => e.CurrencyId);

            builder.HasMany(e => e.PurchaseOrders)
    .WithOne(e => e.Currency)
    .HasForeignKey(e => e.CurrencyId);

            builder.HasMany(e => e.WholeSaleOrders)
    .WithOne(e => e.Currency)
    .HasForeignKey(e => e.CurrencyId);
        }
    }
}
