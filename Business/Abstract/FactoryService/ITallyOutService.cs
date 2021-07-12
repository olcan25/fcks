using System.Collections.Generic;
using Core.Utilities.Result;
using Entity.Concrete;

namespace Business.Abstract.FactoryService
{
    public interface ITallyOutService
    {
        IResult Add(Ledger ledger, WholeSaleOrder wholeSaleOrder, List<WholeSaleOrderLine> wholeSaleOrderLines);
        IResult Delete(int id);
        IResult Update(Ledger ledger, WholeSaleOrder wholeSaleOrder, List<WholeSaleOrderLine> wholeSaleOrderLines);
    }
}
