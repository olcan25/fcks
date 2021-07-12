using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.EfMapping
{
    public class EfCompanyMap : BaseEntityMap<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            base.Configure(builder);

            builder.ToTable("Companies", "Companies");

            builder.HasKey(x => x.Id);

            builder.Property(c => c.Name).HasMaxLength(500);

            builder.Property(c => c.Period).HasMaxLength(4);

            builder.Property(c => c.UniqueIdentificationNumber).HasMaxLength(9);

            builder.Property(c => c.VatNumber).HasMaxLength(9);

            builder.HasMany(c => c.Warehouses)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId);

            builder.HasMany(c => c.CompanyBankAccounts)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId);
        }
    }
}
