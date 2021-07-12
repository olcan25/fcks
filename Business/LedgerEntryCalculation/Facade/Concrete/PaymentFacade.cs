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
    public class PaymentFacade : IPaymentFacade
    {
        private readonly IPaymentFinancialService _paymentFinancialService;
        public PaymentFacade(IPaymentFinancialService paymentFinancialService)
        {
            _paymentFinancialService = paymentFinancialService;
        }
        public List<LedgerEntry> FinancialPaymentSystem(Payment payment)
        {
            List<LedgerEntry> ledgerEntries = new List<LedgerEntry>
            {
                _paymentFinancialService.FinancialPartnerPayment(payment),
                _paymentFinancialService.FinancialCashPayment(payment)
            };
            return ledgerEntries;
        }
    }
}
