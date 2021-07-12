using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.EfMapping
{
    public class EfCategoryMap : BaseEntityMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.ToTable("Categories", schema: "Products");

            builder.HasKey(x => x.Id);

            builder.Property(b => b.Name).HasMaxLength(100);

            builder.Property(c => c.Description).HasMaxLength(200);

            builder.HasMany(c => c.Products)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId)
                .IsRequired(false);
        }
    }
}
