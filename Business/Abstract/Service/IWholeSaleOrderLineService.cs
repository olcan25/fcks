using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concrete;
using Entity.Dto.Invoice;
using Entity.Dto.WholeSaleOrder;

namespace Business.Abstract.Service
{
    public interface IWholeSaleOrderLineService
    {
        IDataResult<List<WholeSaleOrderLine>> GetAllWholeSaleOrderLines();
        IDataResult<List<WholeSaleOrderLine>> GetByWholeSaleOrderIdWholeSaleOrderLines(long wholeSaleOrderId);
        IDataResult<List<InvoiceLine>> GetAllInvoiceLines();
        IDataResult<List<InvoiceLine>> GetByWholeSaleOrderIdInvoiceLines(long wholeSaleOrderId);
        IResult Add(WholeSaleOrderLine wholeSaleOrderLine);
        IResult Delete(WholeSaleOrderLine wholeSaleOrderLine);
        IResult Update(WholeSaleOrderLine wholeSaleOrderLine);
        IResult BulkAdd(List<WholeSaleOrderLine> wholeSaleOrderLines);
        IResult BulkDelete(List<WholeSaleOrderLine> wholeSaleOrderLines);
        IResult BulkUpdate(List<WholeSaleOrderLine> wholeSaleOrderLines);
    }
}
