using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.EfMapping
{
    public class EfPaymentMap : BaseEntityMap<Payment>
    {
        public override void Configure(EntityTypeBuilder<Payment> builder)
        {
            base.Configure(builder);

            builder.ToTable("Payments", "Payments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();


            builder.Property(x => x.Description).HasMaxLength(250);

            builder.Property(x => x.Note).HasMaxLength(500);

            builder.HasOne(x => x.Ledger)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.LedgerId);

            builder.HasOne(x => x.Partner)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.PartnerId);

            builder.HasOne(x => x.PaymentType)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.PaymentTypeId);

            builder.HasOne(x => x.Account)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.AccountId);
        }
    }
}
