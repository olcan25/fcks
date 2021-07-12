using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.PurchaseOrderLine
{
    public class PurchaseOrderLineDto
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }
        public byte WarehouseId { get; set; }
        public byte VatId { get; set; }


        public float Quantity { get; set; }
        public float DiscountRate { get; set; }
        public float DiscountValue { get; set; }
        public float UnitPrice { get; set; }
        public float VatValue { get; set; }
        public float Amount { get; set; }
    }
}
