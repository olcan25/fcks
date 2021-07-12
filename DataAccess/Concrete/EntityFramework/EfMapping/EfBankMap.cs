using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.EfMapping
{
    public class EfBankMap : BaseEntityMap<Bank>
    {
        public override void Configure(EntityTypeBuilder<Bank> builder)
        {
            base.Configure(builder);

            builder.ToTable("Banks", schema: "Banks");

            builder.Property(b => b.ShortName).HasMaxLength(15);

            builder.Property(b => b.Name).HasMaxLength(100);

            builder.HasMany(b => b.CompanyBankAccounts)
                .WithOne(b => b.Bank)
                .HasForeignKey(b => b.BankId);

            builder.HasMany(b => b.PartnerBankAccounts)
                .WithOne(b => b.Bank)
                .HasForeignKey(b => b.BankId);
        }
    }
}
