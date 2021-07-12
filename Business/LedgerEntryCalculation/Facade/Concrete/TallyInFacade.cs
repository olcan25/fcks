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
    public class TallyInFacade:ITallyInFacade
    {
        private readonly ITallyInFinancialService _tallyInFinancialService;
        public TallyInFacade(ITallyInFinancialService tallyInFinancialService)
        {
            _tallyInFinancialService = tallyInFinancialService;
        }

        public List<LedgerEntry> RegisterGoods(List<PurchaseOrderLine> purchaseOrderLines, long ledgerId)
        {
            List<LedgerEntry> ledgerEntries = new List<LedgerEntry>();
            ledgerEntries.Add(_tallyInFinancialService.RegisterGoods(purchaseOrderLines, ledgerId));
            ledgerEntries.Add(_tallyInFinancialService.Seller(purchaseOrderLines, ledgerId));
            if (purchaseOrderLines.Any(x => x.VatId == 2))
            {
                ledgerEntries.Add(_tallyInFinancialService.DeductibleVat8(purchaseOrderLines, ledgerId));
            }

            if (purchaseOrderLines.Any(x => x.VatId == 3))
            {
                ledgerEntries.Add(_tallyInFinancialService.DeductibleVat18(purchaseOrderLines, ledgerId));
            }

            return ledgerEntries;
        }
    }
}
