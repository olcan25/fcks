using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.LedgerEntryCalculation.Facade.Abstract
{
    public interface ITallyInFacade
    {
        List<LedgerEntry> RegisterGoods(List<PurchaseOrderLine> purchaseOrderLines, long ledgerId);
    }
}
