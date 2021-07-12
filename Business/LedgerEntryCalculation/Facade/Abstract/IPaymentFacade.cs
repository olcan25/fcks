using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.LedgerEntryCalculation.Facade.Abstract
{
    public interface IPaymentFacade
    {
        List<LedgerEntry> FinancialPaymentSystem(Payment payment);
    }
}
