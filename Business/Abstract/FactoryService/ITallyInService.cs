using System.Collections.Generic;
using Core.Utilities.Result;
using Entity.Concrete;

namespace Business.Abstract.FactoryService
{
    public interface ITallyInService
    {
        IResult Add(Ledger ledger, PurchaseOrder purchaseOrder, List<PurchaseOrderLine> purchaseOrderLines);
        IResult Delete(int id);
        IResult Update(Ledger ledger, PurchaseOrder purchaseOrder, List<PurchaseOrderLine> purchaseOrderLines);
    }
}
