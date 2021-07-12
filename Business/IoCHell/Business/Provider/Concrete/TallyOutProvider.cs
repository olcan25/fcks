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
    public class TallyOutProvider : ITallyOutProvider
    {
        public ILedgerService LedgerService { get; set; }
        public IWholeSaleOrderService WholeSaleOrderService { get; set; }
        public IWholeSaleOrderLineService WholeSaleOrderLineService { get; set; }
        public IPaymentService PaymentService { get; set; }
        public ILedgerEntryService LedgerEntryService { get; set; }
        public IProductService ProductService { get; set; }

        public TallyOutProvider(ILedgerService ledgerService, IWholeSaleOrderService wholeSaleOrderService, IWholeSaleOrderLineService wholeSaleOrderLineService, IPaymentService paymentService, ILedgerEntryService ledgerEntryService, IProductService productService)
        {
            LedgerService = ledgerService;
            WholeSaleOrderService = wholeSaleOrderService;
            WholeSaleOrderLineService = wholeSaleOrderLineService;
            PaymentService = paymentService;
            LedgerEntryService = ledgerEntryService;
            ProductService = productService;
        }
    }
}
