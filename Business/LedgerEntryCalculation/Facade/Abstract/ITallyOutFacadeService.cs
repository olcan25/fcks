using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.LedgerEntryCalculation.Facade.Abstract
{
    public interface ITallyOutFacadeService
    {
        List<LedgerEntry> SaleOfGoods(List<WholeSaleOrderLine> wholeSaleOrderLines, long ledgerId);
    }
}
