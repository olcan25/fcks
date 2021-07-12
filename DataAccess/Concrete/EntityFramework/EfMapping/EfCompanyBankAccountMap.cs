using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.EfMapping
{
    public class EfCompanyBankAccountMap : BaseEntityMap<CompanyBankAccount>
    {
        public override void Configure(EntityTypeBuilder<CompanyBankAccount> builder)
        {
            base.Configure(builder);

            builder.ToTable("CompanyBankAccounts", "Banks");

            builder.HasKey(x => x.Id);

            builder.Property(c => c.AccountNumber).HasMaxLength(25);

            builder.Property(x => x.Iban).HasMaxLength(30);

            builder.Property(x => x.SwiftCode).HasMaxLength(15);

            builder.HasOne(c => c.Bank)
                .WithMany(c => c.CompanyBankAccounts)
                .HasForeignKey(c => c.BankId);

            builder.HasOne(c => c.Company)
                .WithMany(c => c.CompanyBankAccounts)
                .HasForeignKey(c => c.CompanyId);
        }
    }
}
