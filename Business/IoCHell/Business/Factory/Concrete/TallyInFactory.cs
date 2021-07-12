using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.FactoryService;
using Business.Abstract.Service;
using Business.IoCHell.Business.Factory.Abstract;
using Business.IoCHell.Business.Provider.Abstract;
using Business.IoCHell.Business.Provider.Concrete;

namespace Business.IoCHell.Business.Factory.Concrete
{
    public class TallyInFactory : ITallyInFactory
    {
        private readonly ILedgerService _ledgerService;
        private readonly IPurchaseOrderService _purchaseOrderService;
        private readonly IPurchaseOrderLineService _purchaseOrderLineService;
        private readonly IPaymentService _paymentService;
        private readonly ILedgerEntryService _ledgerEntryService;
        private readonly IProductService _productService;

        public TallyInFactory(ILedgerService ledgerService, IPurchaseOrderService purchaseOrderService, IPurchaseOrderLineService purchaseOrderLineService, IPaymentService paymentService, ILedgerEntryService ledgerEntryService,IProductService productService)
        {
            _ledgerService = ledgerService;
            _purchaseOrderService = purchaseOrderService;
            _purchaseOrderLineService = purchaseOrderLineService;
            _paymentService = paymentService;
            _ledgerEntryService = ledgerEntryService;
            _productService = productService;
        }

        public ITallyInProvider Create()
        {
            return new TallyInProvider(_ledgerService, _purchaseOrderService, _purchaseOrderLineService, _paymentService, _ledgerEntryService, _productService);
        }
    }
}
