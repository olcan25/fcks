using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.Service;
using Core.Utilities.Result;
using Entity.Dto.Invoice;
using Entity.Dto.WholeSaleOrder;

namespace Business.Concrete.Manager
{
    public class InvoiceManager:IInvoiceService
    {
        private readonly IWholeSaleOrderLineService _wholeSaleOrderLineService;
        private readonly IWholeSaleOrderService _wholeSaleOrderService;

        public InvoiceManager(IWholeSaleOrderLineService wholeSaleOrderLineService, IWholeSaleOrderService wholeSaleOrderService)
        {
            _wholeSaleOrderLineService = wholeSaleOrderLineService;
            _wholeSaleOrderService = wholeSaleOrderService;
        }
        public IDataResult<List<InvoiceLine>> GetAllInvoiceLines()
        {
            return new SuccessDataResult<List<InvoiceLine>>(_wholeSaleOrderLineService.GetAllInvoiceLines().Data);
        }

        public IDataResult<List<InvoiceLine>> GetByWholeSaleOrderInvoiceLines(int wholeSaleOrderId)
        {
            return new SuccessDataResult<List<InvoiceLine>>(_wholeSaleOrderLineService
                .GetByWholeSaleOrderIdInvoiceLines(wholeSaleOrderId).Data);
        }

        public IDataResult<List<InvoiceHead>> GetAllInvoiceHeads()
        {
            return new SuccessDataResult<List<InvoiceHead>>(_wholeSaleOrderService.GetAllInvoiceHeads().Data);
        }

        public IDataResult<InvoiceHead> GetByIdInvoiceHead(int wholeSaleOrderId)
        {
            return new SuccessDataResult<InvoiceHead>(_wholeSaleOrderService.GetByIdInvoiceHead(wholeSaleOrderId).Data);
        }
    }
}
