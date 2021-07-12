using System.Collections.Generic;
using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Product : BaseEntity, IEntity
    {
        public Product()
        {
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
            WholeSaleOrderLines = new HashSet<WholeSaleOrderLine>();
        }

        public long Id { get; set; }
        public byte VatId { get; set; }
        public short? CategoryId { get; set; }
        public short UnitOfMeasureId { get; set; }
        public byte ProductTypeId { get; set; } = 1;
        public long AccountId { get; set; }
        public float? CustomsTaxRate { get; set; }
        public float? ExciseTaxRate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? DefaultBuyingPrice { get; set; } = 0;
        public decimal? DefaultSellingPrice { get; set; } = 0;

        public string ImagePath { get; set; }


        public ProductType ProductType { get; set; }
        public Vat Vat { get; set; }
        public Category Category { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }

        public ICollection<ProductBarcode> ProductBarcodes { get; set; }
        public ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public ICollection<WholeSaleOrderLine> WholeSaleOrderLines { get; set; }
    }
}
