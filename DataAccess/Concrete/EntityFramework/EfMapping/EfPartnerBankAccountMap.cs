using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.EfMapping
{
    public class EfPartnerBankAccountMap : BaseEntityMap<PartnerBankAccount>
    {
        public override void Configure(EntityTypeBuilder<PartnerBankAccount> builder)
        {
            base.Configure(builder);

            builder.ToTable("PartnerBankAccounts", "Banks");

            builder.HasKey(x => x.Id);

            builder.HasKey(x => x.Id);

            builder.Property(c => c.AccountNumber).HasMaxLength(25);

            builder.Property(x => x.Iban).HasMaxLength(30);

            builder.Property(x => x.SwiftCode).HasMaxLength(15);
            
            builder.HasOne(p => p.Partner)
                .WithMany(p => p.PartnerBankAccounts)
                .HasForeignKey(p => p.PartnerId);

            builder.HasOne(p => p.Bank)
                .WithMany(p => p.PartnerBankAccounts)
                .HasForeignKey(p => p.BankId);
        }
    }
}
