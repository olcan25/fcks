using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.EfMapping
{
    public class EfUnitOfMeasureMap : BaseEntityMap<UnitOfMeasure>
    {
        public override void Configure(EntityTypeBuilder<UnitOfMeasure> builder)
        {
            base.Configure(builder);

            builder.ToTable("UnitOfMeasures", "Products");

            builder.HasKey(x => x.Id);

            builder.Property(u => u.Name).HasMaxLength(40);

            builder.Property(u => u.ShortName).HasMaxLength(4);

            builder.HasMany(u => u.Products)
                .WithOne(u => u.UnitOfMeasure)
                .HasForeignKey(u => u.UnitOfMeasureId);
        }
    }
}
