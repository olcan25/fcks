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
    public class EfProductTypeMap:BaseEntityMap<ProductType>
    {
        public override void Configure(EntityTypeBuilder<ProductType> builder)
        {
            base.Configure(builder);

            builder.ToTable("ProductTypes", "Products");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasMaxLength(30);

            builder.Property(x => x.Description).HasMaxLength(250);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.ProductType)
                .HasForeignKey(x => x.ProductTypeId);
        }
    }
}
