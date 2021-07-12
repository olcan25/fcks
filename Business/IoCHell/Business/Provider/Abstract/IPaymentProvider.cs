using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.Service;

namespace Business.IoCHell.Business.Provider.Abstract
{
    public interface IPaymentProvider
    {
        ILedgerService LedgerService { get; set; }
        IPaymentService PaymentService { get; set; }
        ILedgerEntryService LedgerEntryService { get; set; }
    }
}
