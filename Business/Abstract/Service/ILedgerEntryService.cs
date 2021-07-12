using Core.Utilities.Result;
using Entity.Concrete;
using Entity.Dto.LedgerEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Service
{
    public interface ILedgerEntryService
    {
        IDataResult<List<LedgerEntry>> GetAllLedgerEntries();
        IDataResult<List<LedgerEntry>> GetAllByLedgerIdLedgerEntries(long ledgerId);
        IDataResult<List<LedgerAccountDto>> GetAllLedgerAccountsDtoList();
        IDataResult<List<LedgerAccountDto>> GetAllLedgerAccountsDtoList(DateTime startDate, DateTime endDate);

        IDataResult<LedgerEntry> GetByIdLedgerEntry(int id);
        IResult Add(LedgerEntry ledgerEntry);
        IResult Delete(LedgerEntry ledgerEntry);
        IResult Update(LedgerEntry ledgerEntry);

        IResult AddBulk(List<LedgerEntry> ledgerEntries);
        IResult DeleteBulk(List<LedgerEntry> ledgerEntries);
        IResult UpdateBulk(List<LedgerEntry> ledgerEntries);
    }
}
