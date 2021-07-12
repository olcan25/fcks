using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class PurchaseOrderLine : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public long PurchaseOrderId { get; set; }
        public long ProductId { get; set; }
        public int WarehouseId { get; set; }
        public byte VatId { get; set; }

        public float? DiscountRate { get; set; } = 0;
        public float? CustomsTaxRate { get; set; } = 0;//Dogana Oran
        //public float? ExciseTaxRate { get; set; } = 0;//Akciza Oran



        public decimal? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? DiscountUnitPrice { get; set; }
        public decimal? VatUnitPrice { get; set; }
        public decimal? CustomsTaxUnitPrice { get; set; }//Dogana
        public decimal? ExciseTaxUnitPrice { get; set; }//Akciza
        public decimal? TransporterUnitPrice { get; set; }
        public decimal? ReEvaluationUnitPrice { get; set; }//Rivlersim
        public decimal? GrossWithOutVatUnitPrice { get; set; }//Indirim dogana vat sonrasi fakt kdvsiz cmimiMesatare icin
        public decimal? GrossUnitPrice { get; set; }


        public decimal? Amount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? VatAmount { get; set; }
        public decimal? CustomsTaxAmount { get; set; }//Dogana
        public decimal? ExciseTaxAmount { get; set; }//Akciza
        public decimal? TransporterAmount { get; set; }
        public decimal? ReEvaluationAmount { get; set; }//Rivlersim
        public decimal? GrossWithOutVatAmount { get; set; }
        public decimal? GrossAmount { get; set; }

        public Product Product { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public Warehouse Warehouse { get; set; }
        public Vat Vat { get; set; }
    }
}
