using Business.ViewModel;
using Core.Utilities.Result;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.FactoryService
{
    public interface ILedgerAccountService
    {
        IResult Add(Ledger ledger, List<LedgerEntry> ledgerEntries);
        IResult Delete(long id);
        IResult Update(Ledger ledger, List<LedgerEntry> ledgerEntries);
    }
}
