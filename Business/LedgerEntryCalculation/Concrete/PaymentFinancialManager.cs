using Business.LedgerEntryCalculation.Abstract;
using Entity.Concrete;

namespace Business.LedgerEntryCalculation.Concrete
{
    public class PaymentFinancialManager : IPaymentFinancialService
    {
        public LedgerEntry FinancialCashPayment(Payment payment)
        {
            if (payment.PaymentTypeId == 1)
            {
                var ledgerEntry = new LedgerEntry
                {
                    LedgerId = payment.LedgerId,
                    AccountId = payment.AccountId,
                    //EntryType = false,
                    //Amount = payment.Amount
                    Debt = 0,
                    Credit = payment.Amount
                };
                return ledgerEntry;
            }
            else if (payment.PaymentTypeId == 2)
            {
                var ledgerEntry = new LedgerEntry
                {
                    LedgerId = payment.LedgerId,
                    AccountId = payment.AccountId,
                    //EntryType = true,
                    //Amount = payment.Amount
                    Debt = payment.Amount,
                    Credit = 0
                };
                return ledgerEntry;
            }
            else
            {
                throw new System.Exception();
            }
        }

        public LedgerEntry FinancialPartnerPayment(Payment payment)
        {
            if (payment.PaymentTypeId == 1)
            {
                var ledgerEntry = new LedgerEntry
                {
                    LedgerId = payment.LedgerId,
                    AccountId = "320000",
                    //EntryType = true,
                    //Amount = payment.Amount
                    Debt = payment.Amount,
                    Credit = 0
                };
                return ledgerEntry;
            }
            else if (payment.PaymentTypeId == 2)
            {
                var ledgerEntry = new LedgerEntry
                {
                    LedgerId = payment.LedgerId,
                    AccountId = "120000",
                    //EntryType = false,
                    //Amount = payment.Amount
                    Debt = 0,
                    Credit = payment.Amount
                };
                return ledgerEntry;
            }
            else
            {
                throw new System.Exception();
            }
        }
    }
}
