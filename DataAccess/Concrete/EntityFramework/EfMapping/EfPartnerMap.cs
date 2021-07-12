using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.EfMapping
{
    public class EfPartnerMap : BaseEntityMap<Partner>
    {
        public override void Configure(EntityTypeBuilder<Partner> builder)
        {
            base.Configure(builder);

            builder.ToTable("Partners", "Partners");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Address).HasMaxLength(250);

            builder.Property(p => p.AdditionalInformation).HasMaxLength(250);

            builder.Property(p => p.City).HasMaxLength(100);

            builder.Property(p => p.Country).HasMaxLength(100);

            builder.Property(p => p.ContactName).HasMaxLength(40);

            builder.Property(p => p.Email).HasMaxLength(50);

            builder.Property(p => p.Fax).HasMaxLength(30);

            builder.Property(p => p.Name).HasMaxLength(250);

            builder.Property(p => p.Phone).HasMaxLength(30);

            builder.Property(p => p.UniqueIdentificationNumber).HasMaxLength(9);

            builder.Property(p => p.VatNumber).HasMaxLength(9);

            builder.Property(p => p.Website).HasMaxLength(100);

            builder.Property(p => p.ZipCode).HasMaxLength(10);

            builder.HasMany(x => x.PartnerBankAccounts)
                .WithOne(x => x.Partner)
                .HasForeignKey(x => x.PartnerId);

            builder.HasMany(x => x.PartnerPurchaseOrders)//Partner Id
                .WithOne(x => x.Partner)
                .HasForeignKey(x => x.PartnerId);

            builder.HasMany(x => x.TransporterPurchaseOrders)//TransporterId
                .WithOne(x => x.Transporter)
                .HasForeignKey(x => x.TransporterId)
                .IsRequired(false);

            builder.HasMany(p => p.WholeSaleOrders)
                .WithOne(p => p.Partner)
                .HasForeignKey(p => p.PartnerId);

            builder.HasMany(p => p.Payments)
                .WithOne(p => p.Partner)
                .HasForeignKey(p => p.PartnerId);

            builder.HasOne(x => x.PartnerType)
                .WithMany(x => x.Partners)
                .HasForeignKey(x => x.PartnerTypeId);

        }
    }
}
