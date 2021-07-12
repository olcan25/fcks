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
    public class EfWarehouseTypeMap:BaseEntityMap<WarehouseType>
    {
        public override void Configure(EntityTypeBuilder<WarehouseType> builder)
        {
            base.Configure(builder);

            builder.ToTable("WarehouseTypes", "Warehouses");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(250);

            builder.Property(x => x.Description).HasMaxLength(500);

            builder.HasMany(x => x.Warehouses)
                .WithOne(x => x.WarehouseType)
                .HasForeignKey(x => x.WarehouseTypeId);
        }
    }
}
