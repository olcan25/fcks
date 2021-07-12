using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.Service;
using Business.IoCHell.Business.Factory.Abstract;
using Business.IoCHell.Business.Provider.Abstract;
using Business.IoCHell.Business.Provider.Concrete;

namespace Business.IoCHell.Business.Factory.Concrete
{
    public class PaymentFactory : IPaymentFactory
    {
        private readonly IPaymentService _paymentService;
        private readonly ILedgerService _ledgerService;
        private readonly ILedgerEntryService _ledgerEntryService;

        public PaymentFactory(IPaymentService paymentService, ILedgerService ledgerService, ILedgerEntryService ledgerEntryService)
        {
            _paymentService = paymentService;
            _ledgerService = ledgerService;
            _ledgerEntryService = ledgerEntryService;
        }
        public IPaymentProvider Create()
        {
            return new PaymentProvider(_ledgerService, _paymentService, _ledgerEntryService);
        }
    }
}
