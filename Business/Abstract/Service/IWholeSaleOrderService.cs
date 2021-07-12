using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using Entity.Dto.Invoice;
using Entity.Dto.WholeSaleOrder;

namespace Business.Abstract.Service
{
    public interface IWholeSaleOrderService
    {
        IDataResult<List<WholeSaleOrder>> GetAllWholeSaleOrders();
        IDataResult<WholeSaleOrder> GetByIdWholeSaleOrder(int id);
        IDataResult<WholeSaleOrder> GetByLedgerIdWholeSaleOrder(long ledgerId);
        IDataResult<List<GetWholeSaleOrderDto>> GetAllWholeSaleOrdersDto();
        IDataResult<GetWholeSaleOrderDto> GetByIdWholeSaleOrderDto(int id);
        IDataResult<List<InvoiceHead>> GetAllInvoiceHeads();
        IDataResult<InvoiceHead> GetByIdInvoiceHead(int wholeSaleOrderId);
        IResult Add(WholeSaleOrder wholeSaleOrder);
        IResult Delete(WholeSaleOrder wholeSaleOrder);
        IResult Update(WholeSaleOrder wholeSaleOrder);

    }
}
