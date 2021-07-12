using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.Service;
using Business.IoCHell.Business.Provider.Abstract;

namespace Business.IoCHell.Business.Provider.Concrete
{
    public class PaymentProvider : IPaymentProvider
    {
        public ILedgerService LedgerService { get; set; }
        public IPaymentService PaymentService { get; set; }
        public ILedgerEntryService LedgerEntryService { get; set; }

        public PaymentProvider(ILedgerService ledgerService, IPaymentService paymentService, ILedgerEntryService ledgerEntryService)
        {
            LedgerService = ledgerService;
            PaymentService = paymentService;
            LedgerEntryService = ledgerEntryService;
        }
    }
}
