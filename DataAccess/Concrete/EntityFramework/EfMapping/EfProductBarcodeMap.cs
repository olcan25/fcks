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
    public class EfProductBarcodeMap:BaseEntityMap<ProductBarcode>
    {
        public override void Configure(EntityTypeBuilder<ProductBarcode> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.ToTable("ProductBarcodes", "Products");

            builder.Property(x => x.Barcode).HasMaxLength(25);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductBarcodes)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
