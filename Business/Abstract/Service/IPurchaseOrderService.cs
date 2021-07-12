using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concrete;
using Entity.Dto.PurchaseOrder;

namespace Business.Abstract.Service
{
    public interface IPurchaseOrderService
    {
        IDataResult<List<PurchaseOrder>> GetAllPurchaseOrders();
        IDataResult<PurchaseOrder> GetByIdPurchaseOrder(int id);
        IDataResult<PurchaseOrder> GetByLedgerIdPurchaseOrder(long ledgerId);
        IDataResult<List<GetPurchaseOrderDto>> GetAllPurchaseOrderDtos();
        IDataResult<GetPurchaseOrderDto> GetByIdPurchaseOrderDto(int id);
        IResult Add(PurchaseOrder purchaseOrder);
        IResult Delete(PurchaseOrder purchaseOrder);
        IResult Update(PurchaseOrder purchaseOrder);
    }
}
