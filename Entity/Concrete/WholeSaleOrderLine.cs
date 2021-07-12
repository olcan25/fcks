using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class WholeSaleOrderLine : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public long WholeSaleOrderId { get; set; }
        public long ProductId { get; set; }
        public int WarehouseId { get; set; }
        public byte VatId { get; set; }

        public decimal? DiscountRate { get; set; }

        //Unit Price
        public decimal? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? DiscountUnitPrice { get; set; }
        public decimal? VatUnitPrice { get; set; }
        public decimal? UnitPriceWithVat { get; set; }


        //Amount
        public decimal? Amount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? VatAmount { get; set; }
        public decimal? AmountWithVat { get; set; }

        public WholeSaleOrder WholeSaleOrder { get; set; }
        public Product Product { get; set; }
        public Warehouse Warehouse { get; set; }
        public Vat Vat { get; set; }
    }
}
