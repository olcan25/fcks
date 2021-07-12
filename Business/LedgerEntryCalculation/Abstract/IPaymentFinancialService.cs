using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.LedgerEntryCalculation.Abstract
{
    public interface IPaymentFinancialService
    {
        LedgerEntry FinancialCashPayment(Payment payment);
        LedgerEntry FinancialPartnerPayment(Payment payment);
    }
}
