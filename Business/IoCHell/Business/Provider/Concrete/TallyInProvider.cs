using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.FactoryService;
using Business.Abstract.Service;
using Business.IoCHell.Business.Provider.Abstract;

namespace Business.IoCHell.Business.Provider.Concrete
{
    public class TallyInProvider : ITallyInProvider
    {
        public ILedgerService LedgerService { get; set; }
        public IPurchaseOrderService PurchaseOrderService { get; set; }
        public IPurchaseOrderLineService PurchaseOrderLineService { get; set; }
        public IPaymentService PaymentService { get; set; }
        public ILedgerEntryService LedgerEntryService { get; set; }
        public IProductService ProductService { get; set; }

        public TallyInProvider(ILedgerService ledgerService, IPurchaseOrderService purchaseOrderService, IPurchaseOrderLineService purchaseOrderLineService, IPaymentService paymentService, ILedgerEntryService ledgerEntryService, IProductService productService)
        {
            LedgerService = ledgerService;
            PurchaseOrderService = purchaseOrderService;
            PurchaseOrderLineService = purchaseOrderLineService;
            PaymentService = paymentService;
            LedgerEntryService = ledgerEntryService;
            ProductService = productService;
        }
    }
}