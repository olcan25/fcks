using Business.LedgerEntryCalculation.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.LedgerEntryCalculation.Concrete
{
    public class TallyInFinancialManager : ITallyInFinancialService
    {
        public LedgerEntry DeductibleVat18(List<PurchaseOrderLine> purchaseOrderLines, long ledgerId)
        {
            var ledgerEntry = new LedgerEntry
            {
                LedgerId = ledgerId,
                AccountId = "191018",
                //EntryType = true,
                //Amount = purchaseOrderLines.Where(x => x.VatId == 3).Sum(x => x.AmountVatValue)
                Debt = purchaseOrderLines.Where(x => x.VatId == 3).Sum(x => x.VatAmount),
                Credit = 0
            };
            return ledgerEntry;
        }

        public LedgerEntry DeductibleVat8(List<PurchaseOrderLine> purchaseOrderLines, long ledgerId)
        {
            var ledgerEntry = new LedgerEntry
            {
                LedgerId = ledgerId,
                AccountId = "191008",
                //EntryType = true,
                //Amount = purchaseOrderLines.Where(x => x.VatId == 2).Sum(x => x.AmountVatValue)
                Debt = purchaseOrderLines.Where(x => x.VatId == 2).Sum(x => x.VatAmount),
                Credit = 0
            };
            return ledgerEntry;
        }

        public LedgerEntry RegisterGoods(List<PurchaseOrderLine> purchaseOrderLines, long ledgerId)
        {
            string accountId = (153000 + purchaseOrderLines[0].WarehouseId).ToString();
            var ledgerEntry = new LedgerEntry
            {
                LedgerId = ledgerId,
                AccountId = accountId,
                //EntryType = true,
                //Amount = purchaseOrderLines.Sum(x => x.Amount)
                Debt = purchaseOrderLines.Sum(x => x.GrossWithOutVatAmount),
                Credit = 0
            };
            return ledgerEntry;
        }

        public LedgerEntry Seller(List<PurchaseOrderLine> purchaseOrderLines, long ledgerId)
        {
            var ledgerEntry = new LedgerEntry
            {
                LedgerId = ledgerId,
                AccountId = "320000",
                //EntryType = false,
                //Amount = purchaseOrderLines.Sum(x => x.AmountWithVat)
                Debt = 0,
                Credit = purchaseOrderLines.Sum(x => x.GrossAmount)
            };

            return ledgerEntry;
        }
    }
}
