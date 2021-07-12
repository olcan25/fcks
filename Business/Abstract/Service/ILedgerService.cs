using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concrete;

namespace Business.Abstract.Service
{
    public interface ILedgerService
    {
        IDataResult<List<Ledger>> GetAllLedgers();
        IDataResult<List<Ledger>> GetAllLedgers(DateTime startDate, DateTime endDate);
        IDataResult<Ledger> GetByIdLedger(long id);
        IDataResult<Ledger> GetLedgerWithPurchase(long id);
        IDataResult<Ledger> GetLedgerWithWholeSale(long id);
        IResult Add(Ledger ledger);
        IResult Delete(Ledger ledger);
        IResult Update(Ledger ledger);
    }
}
