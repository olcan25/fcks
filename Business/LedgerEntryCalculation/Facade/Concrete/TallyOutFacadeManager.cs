using Business.LedgerEntryCalculation.Abstract;
using Business.LedgerEntryCalculation.Facade.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.LedgerEntryCalculation.Facade.Concrete
{
    public class TallyOutFacadeManager : ITallyOutFacadeService
    {
        private readonly ITallyOutFinancialService _tallyOutFinancailService;
        public TallyOutFacadeManager(ITallyOutFinancialService tallyOutFinancailService)
        {
            _tallyOutFinancailService = tallyOutFinancailService;
        }

        public List<LedgerEntry> SaleOfGoods(List<WholeSaleOrderLine> wholeSaleOrderLines, long ledgerId)
        {
            List<LedgerEntry> ledgerEntries = new List<LedgerEntry>();

            ledgerEntries.Add(_tallyOutFinancailService.Clientele(wholeSaleOrderLines, ledgerId));

            if (wholeSaleOrderLines.Any(x => x.VatId == 1))
            {
                ledgerEntries.Add(_tallyOutFinancailService.Income0(wholeSaleOrderLines, ledgerId));
            }

            if (wholeSaleOrderLines.Any(x => x.VatId == 2))
            {
                ledgerEntries.Add(_tallyOutFinancailService.CalculatedVat8(wholeSaleOrderLines, ledgerId));
                ledgerEntries.Add(_tallyOutFinancailService.Income8(wholeSaleOrderLines, ledgerId));
            }

            if (wholeSaleOrderLines.Any(x => x.VatId == 3))
            {
                ledgerEntries.Add(_tallyOutFinancailService.CalculatedVat18(wholeSaleOrderLines, ledgerId));
                ledgerEntries.Add(_tallyOutFinancailService.Income18(wholeSaleOrderLines, ledgerId));
            }

            return ledgerEntries;
        }
    }
}
