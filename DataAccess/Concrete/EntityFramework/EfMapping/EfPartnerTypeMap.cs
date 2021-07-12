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
    public class EfPartnerTypeMap:BaseEntityMap<PartnerType>
    {
        public override void Configure(EntityTypeBuilder<PartnerType> builder)
        {
            base.Configure(builder);

            builder.ToTable("PartnerTypes", "Partners");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasMaxLength(30);

            builder.Property(x => x.Description).HasMaxLength(250);

            builder.HasMany(x => x.Partners)
                .WithOne(x => x.PartnerType)
                .HasForeignKey(x => x.PartnerTypeId);
        }
    }
}
