using Business.LedgerEntryCalculation.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.LedgerEntryCalculation.Concrete
{
    public class TallyOutFinancialManager : ITallyOutFinancialService
    {
        public LedgerEntry CalculatedVat18(List<WholeSaleOrderLine> wholeSaleOrderLines, long ledgerId)
        {
            var ledgerEntry = new LedgerEntry
            {
                LedgerId = ledgerId,
                AccountId = "391018",
                //EntryType = false,
                //Amount = wholeSaleOrderLines.Where(x => x.VatId == 3).Sum(x => x.AmountVatValue)
                Debt = 0,
                Credit = wholeSaleOrderLines.Where(x => x.VatId == 3).Sum(x => x.VatAmount)
            };
            return ledgerEntry;
        }

        public LedgerEntry CalculatedVat8(List<WholeSaleOrderLine> wholeSaleOrderLines, long ledgerId)
        {
            var ledgerEntry = new LedgerEntry
            {
                LedgerId = ledgerId,
                AccountId = "391008",
                //EntryType = false,
                //Amount = wholeSaleOrderLines.Where(x => x.VatId == 2).Sum(x => x.AmountVatValue)
                Debt = 0,
                Credit = wholeSaleOrderLines.Where(x => x.VatId == 2).Sum(x => x.VatAmount)
            };
            return ledgerEntry;
        }

        public LedgerEntry Clientele(List<WholeSaleOrderLine> wholeSaleOrderLines, long ledgerId)
        {
            var ledgerEntry = new LedgerEntry
            {
                LedgerId = ledgerId,
                AccountId = "120000",
                //EntryType = true,
                //Amount = wholeSaleOrderLines.Sum(x => x.AmountWithVat)
                Debt = wholeSaleOrderLines.Sum(x => x.AmountWithVat),
                Credit = 0
            };

            return ledgerEntry;
        }
        //Gelirleri kdvye gore ayir
        public LedgerEntry Income0(List<WholeSaleOrderLine> wholeSaleOrderLines, long ledgerId)
        {
            var ledgerEntry = new LedgerEntry
            {
                LedgerId = ledgerId,
                AccountId = "600000",
                //EntryType = false,
                //Amount = wholeSaleOrderLines.Where(x => x.VatId == 1).Sum(x => x.Amount)
                Debt = 0,
                Credit = wholeSaleOrderLines.Where(x => x.VatId == 1).Sum(x => x.Amount)
            };

            return ledgerEntry;
        }

        public LedgerEntry Income8(List<WholeSaleOrderLine> wholeSaleOrderLines, long ledgerId)
        {
            var ledgerEntry = new LedgerEntry
            {
                LedgerId = ledgerId,
                AccountId = "600008",
                //EntryType = false,
                //Amount = wholeSaleOrderLines.Where(x => x.VatId == 2).Sum(x => x.Amount)
                Debt = 0,
                Credit = wholeSaleOrderLines.Where(x => x.VatId == 2).Sum(x => x.Amount)
            };

            return ledgerEntry;
        }

        public LedgerEntry Income18(List<WholeSaleOrderLine> wholeSaleOrderLines, long ledgerId)
        {
            var ledgerEntry = new LedgerEntry
            {
                LedgerId = ledgerId,
                AccountId = "600018",
                //EntryType = false,
                //Amount = wholeSaleOrderLines.Where(x => x.VatId == 3).Sum(x => x.Amount)
                Debt = 0,
                Credit = wholeSaleOrderLines.Where(x => x.VatId == 3).Sum(x => x.Amount)
            };

            return ledgerEntry;
        }
    }


}
