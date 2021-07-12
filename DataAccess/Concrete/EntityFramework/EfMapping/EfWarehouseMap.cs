using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.EfMapping
{
    public class EfWarehouseMap : BaseEntityMap<Warehouse>
    {
        public override void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            base.Configure(builder);

            builder.ToTable("Warehouses", "Warehouses");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.Name).HasMaxLength(50);

            builder.Property(b => b.City).HasMaxLength(50);

            builder.Property(b => b.Country).HasMaxLength(100);

            builder.Property(b => b.ZipCode).HasMaxLength(6);

            builder.Property(b => b.AddressDetail).HasMaxLength(250);

            builder.Property(x => x.WarehouseTypeId).HasDefaultValue(1);

            builder.HasMany(w => w.WholeSaleOrderLines)
                .WithOne(w => w.Warehouse)
                .HasForeignKey(w => w.WarehouseId);

            builder.HasMany(w => w.PurchaseOrderLines)
                .WithOne(w => w.Warehouse)
                .HasForeignKey(w => w.WarehouseId);

            builder.HasOne(x => x.Company)
                .WithMany(x => x.Warehouses)
                .HasForeignKey(x => x.CompanyId);

            builder.HasOne(x => x.WarehouseType)
                .WithMany(x => x.Warehouses)
                .HasForeignKey(x => x.WarehouseTypeId);
        }
    }
}
