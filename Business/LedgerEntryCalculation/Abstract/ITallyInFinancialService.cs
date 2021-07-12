using Entity.Concrete;
using System;
using System.Collections.Generic;


namespace Business.LedgerEntryCalculation.Abstract
{
    public interface ITallyInFinancialService
    {
        LedgerEntry RegisterGoods(List<PurchaseOrderLine> purchaseOrderLines, long ledgerId);
        LedgerEntry DeductibleVat8(List<PurchaseOrderLine> purchaseOrderLines, long ledgerId);
        LedgerEntry DeductibleVat18(List<PurchaseOrderLine> purchaseOrderLines, long ledgerId);
        LedgerEntry Seller(List<PurchaseOrderLine> purchaseOrderLines, long ledgerId);
    }
}
