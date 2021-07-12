using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Dto.Invoice;
using Entity.Dto.WholeSaleOrder;

namespace Business.Abstract.Service
{
    public interface IInvoiceService
    {
        IDataResult<List<InvoiceLine>> GetAllInvoiceLines();
        IDataResult<List<InvoiceLine>> GetByWholeSaleOrderInvoiceLines(int wholeSaleOrderId);
        IDataResult<List<InvoiceHead>> GetAllInvoiceHeads();
        IDataResult<InvoiceHead> GetByIdInvoiceHead(int wholeSaleOrderId);
    }
}
