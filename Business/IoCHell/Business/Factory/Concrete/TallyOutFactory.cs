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
    public class TallyOutFactory : ITallyOutFactory
    {
        private readonly ILedgerService _ledgerService;
        private readonly IWholeSaleOrderService _wholeSaleOrderService;
        private readonly IWholeSaleOrderLineService _wholeSaleOrderLineService;
        private readonly IPaymentService _paymentService;
        private readonly ILedgerEntryService _ledgerEntryService;
        private readonly IProductService _productService;

        public TallyOutFactory(ILedgerService ledgerService, IWholeSaleOrderService wholeSaleOrderService, IWholeSaleOrderLineService wholeSaleOrderLineService, IPaymentService paymentService, ILedgerEntryService ledgerEntryService, IProductService productService)
        {
            _ledgerService = ledgerService;
            _wholeSaleOrderService = wholeSaleOrderService;
            _wholeSaleOrderLineService = wholeSaleOrderLineService;
            _paymentService = paymentService;
            _ledgerEntryService = ledgerEntryService;
            _productService = productService;
        }
        public ITallyOutProvider Create()
        {
            return new TallyOutProvider(_ledgerService, _wholeSaleOrderService, _wholeSaleOrderLineService, _paymentService, _ledgerEntryService, _productService);
        }
    }
}
