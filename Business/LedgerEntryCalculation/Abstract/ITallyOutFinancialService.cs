using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.LedgerEntryCalculation.Abstract
{
    public interface ITallyOutFinancialService
    {
        LedgerEntry Clientele(List<WholeSaleOrderLine> wholeSaleOrderLines, long ledgerId);//Alicilar
        LedgerEntry CalculatedVat8(List<WholeSaleOrderLine> wholeSaleOrderLines, long ledgerId);
        LedgerEntry CalculatedVat18(List<WholeSaleOrderLine> wholeSaleOrderLines, long ledgerId);
        LedgerEntry Income0(List<WholeSaleOrderLine> wholeSaleOrderLines, long ledgerId);
        LedgerEntry Income8(List<WholeSaleOrderLine> wholeSaleOrderLines, long ledgerId);
        LedgerEntry Income18(List<WholeSaleOrderLine> wholeSaleOrderLines, long ledgerId);
    }
}
