using System.Collections.Generic;
using Entity.Concrete;

namespace Business.ViewModel
{
    public class PurchaseOrderModel
    {
        public Ledger Ledger { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public List<PurchaseOrderLine> PurchaseOrderLines { get; set; }
    }
}
