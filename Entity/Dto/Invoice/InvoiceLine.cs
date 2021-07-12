using Core.Entity.Abstract;

namespace Entity.Dto.Invoice
{
    public class InvoiceLine:IDto
    {
        public int Id { get; set; }
        public long WholeSaleOrderId { get; set; }
        public string ProductBarcode { get; set; }
        public string ProductName { get; set; }
        public string UnitOfMeasureShortName { get; set; }
        public byte VatId { get; set; }


        public float VatRate { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? UnitPriceDiscountValue { get; set; }
        public decimal? UnitPriceVatValue { get; set; }
        public decimal? UnitPriceWithVat { get; set; }
        public decimal? AmountDiscountValue { get; set; }
        public decimal? AmountVatValue { get; set; } = 0;
        public decimal? Amount { get; set; }
        public decimal? AmountWithVat { get; set; }
    }
}
