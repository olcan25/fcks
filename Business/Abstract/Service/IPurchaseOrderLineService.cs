using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concrete;

namespace Business.Abstract.Service
{
    public interface IPurchaseOrderLineService
    {
        IDataResult<List<PurchaseOrderLine>> GetAllPurchaseOrderLines();
        IDataResult<List<PurchaseOrderLine>> GetByPurchaseOrderIdPurchaseOrderLines(long purchaseOrderId);
        IResult Add(PurchaseOrderLine purchaseOrderLine);
        IResult Delete(PurchaseOrderLine purchaseOrderLine);
        IResult Update(PurchaseOrderLine purchaseOrderLine);
        IResult BulkAdd(List<PurchaseOrderLine> purchaseOrderLines);
        IResult BulkDelete(List<PurchaseOrderLine> purchaseOrderLines);
        IResult BulkUpdate(List<PurchaseOrderLine> purchaseOrderLines);
    }
}
